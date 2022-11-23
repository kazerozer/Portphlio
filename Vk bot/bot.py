import random
import logging
import vk_api
from vk_api.bot_longpoll import VkBotLongPoll, VkBotEventType
import os.path
import handlers
import settings
from anekdots import anekdots
from words_base import pipe
from settings import TOKEN, GROUP_ID

log = logging.getLogger('vk_bot')


def logger_config():
    str_handler = logging.StreamHandler()
    str_handler.setFormatter(logging.Formatter('%(levelname)s %(message)s'))
    str_handler.setLevel(logging.INFO)
    log.addHandler(str_handler)

    file_handler = logging.FileHandler('bot.log', 'a', 'utf-8')
    file_handler.setFormatter(logging.Formatter('%(asctime)s %(levelname)s %(message)s'))
    file_handler.setLevel(logging.DEBUG)
    log.addHandler(file_handler)
    log.setLevel(logging.DEBUG)


class UserState:
    def __init__(self, scenario_name, step_name, context=None ):
        self.scenario_name = scenario_name
        self.step_name = step_name
        self.context = context or {}


class Bot:
    def __init__(self, token, group_id):
        self.token = token
        self.grpid = group_id
        self.vk = vk_api.VkApi(token=self.token)
        self.long_poller = VkBotLongPoll(self.vk, self.grpid)
        self.api = self.vk.get_api()
        self.user_states = dict()
        self.anecdots = False
        self.talk = False

    def run(self):
        for event in self.long_poller.listen():
            try:
                self.on_event(event)
            except Exception:
                print ('Ошибка')
                log.exception('ошибка в обработке события')

    def write_msg(self, id, message):


       if os.path.exists('share_pic.webp'):
           upload = vk_api.VkUpload(self.vk)
           photo = upload.photo_messages('share_pic.webp')
           owner_id = photo[0]['owner_id']
           photo_id = photo[0]['id']
           access_key = photo[0]['access_key']
           attachment = f'photo{owner_id}_{photo_id}_{access_key}'
           self.vk.method('messages.send', {"peer_id": id, 'message': message, "attachment": attachment,
                                            "random_id": random.randint(0, 2 ** 20)})
           os.remove('share_pic.webp')

       else:
           self.vk.method('messages.send', {"peer_id": id, 'message': message, "random_id": random.randint(0, 2 ** 20)})

    def start_scenario(self, id, scenario_name):
        scenario = settings.SCENARIOS[scenario_name]
        first_step = scenario['first_step']
        step = scenario['steps'][first_step]
        text_to_send = step['text']
        self.user_states[id] = UserState(scenario_name=scenario_name, step_name=first_step)
        return text_to_send

    def continue_scenario(self, id, message):
        state = self.user_states[id]
        steps = settings.SCENARIOS[state.scenario_name]['steps']
        step = steps[state.step_name]
        handler = getattr(handlers, step['handler'])
        if handler(text=message, context=state.context):
            next_step = steps[step['next_step']]
            text_to_send = next_step['text'].format(**state.context)
            if next_step['next_step']:
                state.step_name = step['next_step']
            else:
                self.user_states.pop(id)
        else:
            text_to_send = step['failure_text'].format(**state.context)

        return text_to_send

    def on_event(self, event):

        # if event.type == vk_api.bot_longpoll.VkBotEventType.MESSAGE_TYPING_STATE:
        #

        if event.type == VkBotEventType.MESSAGE_NEW:
            # log.debug('Пришло сообщение')
            messages = self.vk.method("messages.getConversations", {"offset": 0, "count": 20, "filter": "unread"})
            if messages["count"] >= 1:
                id = messages["items"][0]["last_message"]["from_id"]
                body = messages["items"][0]["last_message"]["text"]
                message = body.lower()
                user = self.vk.method("users.get", {"user_ids": id})
                fullname = user[0]['first_name']
            if id in self.user_states:
                text_to_send = self.continue_scenario(id, message)

            else:
               for intent in settings.INTENTS:
                  if any(token in message for token in intent['tokens']):
                      if intent['answer']:
                          text_to_send = intent['answer'].format(fullname)
                      else:
                          text_to_send = self.start_scenario(id, intent['scenario'])
                      break
               else:
                   text_to_send = settings.DEFAULT_ANSWER

            self.write_msg(id=id, message=text_to_send)







        else:
            print(event.type)



if __name__ == '__main__':
    logger_config()
    bot = Bot(TOKEN, GROUP_ID)
    bot.run()

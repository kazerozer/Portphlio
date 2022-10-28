import json

import vk_api
from vk_api.bot_longpoll import VkBotLongPoll, VkBotEventType
import os.path

from settings import TOKEN, GROUP_ID

from datetime import datetime
import random

from peewee import *

user = 'root'
password = ''
db_name = 'salon'

db = MySQLDatabase(
    db_name, user=user,
    password=password,
    host='localhost')


class BaseTable(Model):
  
    class Meta:
        database = db


class rabotniki(BaseTable):
   
    # Специалист = TextField()
    # услуга = TextField()
    # время = TimeField()
    # стоимость = DecimalField()
    # клиент = TextField()
    имя = TextField()
    специальность = TextField()
    описание = TextField()
    фото = TextField()


class raspisanie(BaseTable):
  
    Специалист = ForeignKeyField(rabotniki)
    услуга = TextField()
    время = DateTimeField()
    стоимость = DecimalField()
    клиент = TextField()


class Bot:
    def __init__(self, token, group_id):
        self.token = token
        self.grpid = group_id
        self.vk = vk_api.VkApi(token=self.token)
        self.long_poller = VkBotLongPoll(self.vk, self.grpid)
        self.api = self.vk.get_api()
        self.id = ''
        self.talk = False
        self.step = None
        self.keyboard = {}
        self.client = {
            "name": '',
            'uslg': '',
            'spec': '',
            'date': '',
            'time': '',
        }

    def run(self):
        for event in self.long_poller.listen():
            # try:
            self.on_event(event)
        # except Exception:
        #     print('Ошибка ', Exception)

    def get_but(self, text, color, cb_type):

        if cb_type is None:
            return {
                "action": {
                    "type": "text",
                    "payload": "{\"button\": \"" + "1" + "\"}",
                    "label": f"{text}"
                },
                "color": f"{color}"}
        else:
            return {
            "action": {
                "type": "callback",
                "payload": {'type': f'{cb_type}','label':f'{text}'},  # максимум 255 символов
                "label": f"{text}"
            },
            "color": f"{color}"}

    def edit_msg(self, event, message, keyboard, image):
        if image is not None:
            upload = vk_api.VkUpload(self.vk)
            photo = upload.photo_messages(image)
            owner_id = photo[0]['owner_id']
            photo_id = photo[0]['id']
            access_key = photo[0]['access_key']
            attachment = f'photo{owner_id}_{photo_id}_{access_key}'
            self.vk.method('messages.edit',
                          {"peer_id": event.obj.peer_id, 'message': message, "attachment": attachment,
                           'conversation_message_id': event.obj.conversation_message_id,
                           "random_id": random.randint(0, 2 ** 20),
                           'keyboard': keyboard})
        else:
            self.vk.method('messages.edit',
                          {"peer_id": event.obj.peer_id, 'message': message,
                           'conversation_message_id': event.obj.conversation_message_id,
                           "random_id": random.randint(0, 2 ** 20),
                           'keyboard': keyboard})

    def write_msg(self, id, message, keyboard, image):

        if image is not None:
            upload = vk_api.VkUpload(self.vk)
            photo = upload.photo_messages(image)
            owner_id = photo[0]['owner_id']
            photo_id = photo[0]['id']
            access_key = photo[0]['access_key']
            attachment = f'photo{owner_id}_{photo_id}_{access_key}'
            self.vk.method('messages.send', {"peer_id": id, 'message': message, "attachment": attachment,
                                             "random_id": random.randint(0, 2 ** 20), 'keyboard': keyboard})


        else:
            self.vk.method('messages.send',
                           {"peer_id": id, 'message': message, "random_id": random.randint(0, 2 ** 20),
                            'keyboard': keyboard})

    def on_event(self, event):

        ulsgs = ['Педикюр', 'Стилист']

        if event.type == VkBotEventType.MESSAGE_EVENT:
            but_info = event.object.payload

            if but_info.get('type') == 'main':

                self.client['uslg'] = ''
                self.client['spec'] = ''
                self.client['date'] = ''
                self.client['time'] = ''

                self.keyboard = {
                    # "one_time": True,
                    "buttons": [
                        [self.get_but('Наши Услуги', 'primary', 'uslg')],
                        [self.get_but('Наши Специалисты', 'primary', 'Fspeci')],
                        [self.get_but('О нас', 'secondary', 'info')]

                    ],
                    "inline": True
                }
                self.keyboard = json.dumps(self.keyboard, ensure_ascii=False).encode('utf-8')
                self.keyboard = str(self.keyboard.decode('utf-8'))
                self.edit_msg(event, "Здравствуйте, приветствуем вас в салоне Эгоист!", self.keyboard, 'photo/egoist.png')

            if but_info.get('type') == 'info':
                self.keyboard = {
                    # "one_time": True,
                    "buttons": [
                       [self.get_but('Назад', 'negative', 'main')]

                    ],
                    "inline": True
                }
                info = 'Мы открылись в 2000 году.\n\n' \
                       'Постоянное развитие и рост принесли свои результаты.\n\nМы не перестаем удивлять своих клиентов,' \
                       ' предлагая самые  новые и современные  технологии в сфере красоты. \n\n' \
                       'В 2017 году наши салоны красоты, по версии Е1, победили в Народной премии в номинации — Салон красоты года.'
                self.keyboard = json.dumps(self.keyboard, ensure_ascii=False).encode('utf-8')
                self.keyboard = str(self.keyboard.decode('utf-8'))
                self.edit_msg(event, info, self.keyboard, 'photo/map.png')

            elif but_info.get('type') == 'uslg':
                self.client['uslg'] = ''
                self.keyboard = {
                    # "one_time": True,
                    "buttons": [],
                    "inline": True
                }
                for uls in ulsgs:
                    self.keyboard["buttons"].append([self.get_but(uls, 'secondary', 'speci')])
                self.keyboard["buttons"].append([self.get_but('Назад', 'negative', 'main')])
                self.keyboard = json.dumps(self.keyboard, ensure_ascii=False).encode('utf-8')
                self.keyboard = str(self.keyboard.decode('utf-8'))
                self.edit_msg(event, "Наши Услуги", self.keyboard, 'photo/egoist.png')

            elif but_info.get('type') == 'Fspeci':

                self.keyboard = {
                    # "one_time": True,
                    "buttons": [],
                    "inline": True
                }
                for rab in rabotniki.select().order_by(rabotniki.имя):
                    self.keyboard["buttons"].append([
                        {
                            "action": {
                                "type": "callback",
                                "payload": {'type': f'spec', 'label': f'{rab.имя}', 'dop_text':f'{rab.специальность}'},
                                "label": f"{rab.имя} - {rab.специальность}"
                            },
                            "color": f"secondary"}

                        ])
                self.keyboard["buttons"].append([self.get_but('Назад', 'negative', 'main')])
                self.keyboard = json.dumps(self.keyboard, ensure_ascii=False).encode('utf-8')
                self.keyboard = str(self.keyboard.decode('utf-8'))
                self.edit_msg(event, f"{but_info.get('label')}:", self.keyboard, 'photo/egoist.png')



            elif but_info.get('type') == 'speci':
                self.client['spec'] = ''
                if self.client['uslg'] == '':
                    self.client['uslg'] = but_info.get('label')
                self.keyboard = {
                    # "one_time": True,
                    "buttons": [],
                    "inline": True
                }
                for rab in rabotniki.select().where(rabotniki.специальность == self.client['uslg'].lower()).order_by(rabotniki.имя):
                    self.keyboard["buttons"].append([self.get_but(rab.имя, 'secondary', 'spec')])
                self.keyboard["buttons"].append([self.get_but('Назад', 'negative', 'main')])
                self.keyboard = json.dumps(self.keyboard, ensure_ascii=False).encode('utf-8')
                self.keyboard = str(self.keyboard.decode('utf-8'))
                self.edit_msg(event, f"Специалисты по {but_info.get('label')}:", self.keyboard, 'photo/egoist.png')

            elif but_info.get('type') == 'spec':
                self.client['time'] = ''
                if self.client['uslg'] == '':
                    self.client['uslg'] = but_info.get('dop_text')
                if self.client['spec'] == '':
                    self.client['spec'] = but_info.get('label')
                self.keyboard = {
                    # "one_time": True,
                    "buttons": [
                        [self.get_but('Расписание', 'primary', 'raspis')],
                        [self.get_but('Назад', 'negative', 'main')]],
                    "inline": True
                }
                self.keyboard = json.dumps(self.keyboard, ensure_ascii=False).encode('utf-8')
                self.keyboard = str(self.keyboard.decode('utf-8'))
                rab = rabotniki.get(rabotniki.имя == self.client['spec'])
                self.edit_msg(event=event, message=f'{rab.имя}\n\nО специалисте: {rab.описание}', keyboard=self.keyboard,
                               image=rab.фото)
                self.client['date'] = rab.id

            elif but_info.get('type') == 'raspis':
                i = 0
                buttons = []
                self.keyboard = {
                    # "one_time": True,
                    "buttons": [],
                    "inline": True
                }
                for rab in raspisanie.select().where(
                        (raspisanie.Специалист == self.client['date']) & (raspisanie.клиент == 'свободно') & (
                                raspisanie.время.contains('2022-10-03'))).order_by(
                    raspisanie.время):
                    buttons.append(self.get_but(datetime.strftime(rab.время, "%H:%M"), 'secondary', 'time'))
                    i += 1
                    if i > 2:
                        self.keyboard["buttons"].append(buttons)
                        buttons = []
                        i = 0
                if buttons:
                    self.keyboard["buttons"].append(buttons)
                self.keyboard["buttons"].append([self.get_but('Назад', 'negative', 'main')])
                self.keyboard = json.dumps(self.keyboard, ensure_ascii=False).encode('utf-8')
                self.keyboard = str(self.keyboard.decode('utf-8'))
                self.edit_msg(event=event, message=f'Выбирите время ', keyboard=self.keyboard, image=None)

            elif but_info.get('type') == 'time':
                self.client['time'] = but_info.get('label')
                self.keyboard = {
                    # "one_time": True,
                    "buttons": [
                        [{
            "action": {
                "type": "callback",
                "payload": {'type': 'show_snackbar', 'text': 'ВЫ ЗАПИСАНЫ!'},
                "label": f"Да"
            },
            "color": f"positive"}



                            , self.get_but('Нет', 'negative', 'desagry')],
                        ],
                    "inline": True
                }
                self.keyboard = json.dumps(self.keyboard, ensure_ascii=False).encode('utf-8')
                self.keyboard = str(self.keyboard.decode('utf-8'))
                self.edit_msg(event=event,
                               message=f'{self.client["name"]}  вы хотите записаться к специалисту - {self.client["spec"]}, на {self.client["uslg"]} в {self.client["time"]}?',
                               keyboard=self.keyboard, image=None)

            elif but_info.get('type') == 'show_snackbar':
                upd = raspisanie.get((raspisanie.Специалист == self.client['date']) & (
                    raspisanie.время.contains(f'2022-09-30 {self.client["time"]}:00')))
                upd.клиент = self.client['name']
                upd.save()


                self.edit_msg(event=event,
                              message=f'{self.client["name"]}, вы записаны к специалисту - {self.client["spec"]}, на {self.client["uslg"]} в {self.client["time"]}, ждем вас по адресу ул. Луначарского, 182!',
                              keyboard=None, image='photo/map.png')
                self.step = None
                self.client = self.client = {
                    "name": '',
                    'uslg': '',
                    'spec': '',
                    'date': '',
                    'time': '',
                }

                self.talk = False
                self.vk.method('messages.sendMessageEventAnswer',
                               {"event_id": event.object.event_id, "user_id": event.object.user_id,
                                "peer_id": event.object.peer_id, "event_data": json.dumps(event.object.payload)})


            elif but_info.get('type') == 'desagry':

                self.keyboard = {
                    # "one_time": True,
                    "buttons": [
                        [self.get_but('Услуга', 'primary', 'uslg')],
                        [self.get_but('Специалист', 'primary', 'speci')],
                        [self.get_but('Время', 'primary', 'raspis')],
                        [self.get_but('Ввести другое имя', 'primary', 'rename')],

                        [self.get_but('Назад', 'negative', 'time')]],
                    "inline": True
                }
                self.keyboard = json.dumps(self.keyboard, ensure_ascii=False).encode('utf-8')
                self.keyboard = str(self.keyboard.decode('utf-8'))
                self.edit_msg(event=event, message=f'Какой пункт вы хотите изменить:',
                              keyboard=self.keyboard,
                              image=None)

            elif but_info.get('type') == 'rename':
                self.edit_msg(event=event, message=f'Напишите имя под которым вас записать',
                              keyboard=None,
                              image=None)



        elif event.type == VkBotEventType.MESSAGE_NEW:
            messages = self.vk.method("messages.getConversations", {"offset": 0, "count": 20, "filter": "unread"})
            if messages["count"] >= 1:
                id = messages["items"][0]["last_message"]["from_id"]
                self.id = id
                body = messages["items"][0]["last_message"]["text"]
                message = body
                user = self.vk.method("users.get", {"user_ids": id})
                fullname = user[0]['first_name']
                self.client['name'] = fullname

            if self.talk:
                self.client['name'] = message
                self.keyboard = {
                    # "one_time": True,
                    "buttons": [
                        [{
                            "action": {
                                "type": "callback",
                                "payload": {'type': 'show_snackbar', 'text': 'ВЫ ЗАПИСАНЫ!'},
                                "label": f"Да"
                            },
                            "color": f"positive"}

                            , self.get_but('Нет', 'negative', 'desagry')],
                    ],
                    "inline": True
                }
                self.keyboard = json.dumps(self.keyboard, ensure_ascii=False).encode('utf-8')
                self.keyboard = str(self.keyboard.decode('utf-8'))
                self.write_msg(id=id, message=f'{self.client["name"]}, вы хотите записаться к специалисту - {self.client["spec"]}, на {self.client["uslg"]} в {self.client["time"]}?',

                              keyboard=self.keyboard, image=None)




            # elif message in ulsgs:
            #     self.client['uslg'] = message
            #     self.keyboard = {
            #         # "one_time": True,
            #         "buttons": [],
            #         "inline": True
            #     }
            #     for rab in rabotniki.select().where(rabotniki.специальность == message.lower()).order_by(rabotniki.имя):
            #         self.keyboard["buttons"].append([self.get_but(rab.имя, 'secondary')])
            #     self.keyboard["buttons"].append([self.get_but('Назад', 'primary')])
            #     self.keyboard = json.dumps(self.keyboard, ensure_ascii=False).encode('utf-8')
            #     self.keyboard = str(self.keyboard.decode('utf-8'))
            #     self.write_msg(id=id, message=f'Наши специалисты по {message}', keyboard=self.keyboard, image=None)
            #     self.step = 'rabi'
            #
            #
            # elif message == 'Расписание' and self.step != 'rabi':
            #
            #     i = 0
            #     buttons = []
            #     self.keyboard = {
            #         # "one_time": True,
            #         "buttons": [],
            #         "inline": True
            #     }
            #     for rab in raspisanie.select().where(
            #             (raspisanie.Специалист == self.step) & (raspisanie.клиент == 'свободно') & (
            #             raspisanie.время.contains('2022-09-30'))).order_by(
            #         raspisanie.время):
            #         buttons.append(self.get_but(datetime.strftime(rab.время, "%H:%M"), 'secondary'))
            #         i += 1
            #         if i > 3:
            #             self.keyboard["buttons"].append(buttons)
            #             buttons = []
            #             i = 0
            #     self.keyboard["buttons"].append(buttons)
            #     self.keyboard["buttons"].append([self.get_but('Назад', 'primary')])
            #     self.keyboard = json.dumps(self.keyboard, ensure_ascii=False).encode('utf-8')
            #     self.keyboard = str(self.keyboard.decode('utf-8'))
            #     self.write_msg(id=id, message=f'Выбирите время ', keyboard=self.keyboard, image=None)
            #     self.step = 'ss'
            #
            # elif self.step == 'ss':
            #     self.client['time'] = message
            #     self.keyboard = {
            #         # "one_time": True,
            #         "buttons": [
            #
            #             [{
            #                 "action": {
            #                     "type": "callback",
            #                     "payload": {'type':'test_callack'},
            #                     "label": f"Да"
            #                 },
            #                 "color": f"primary"}, self.get_but('Нет', 'primary')]
            #         ],
            #         "inline": True
            #     }
            #     self.keyboard = json.dumps(self.keyboard, ensure_ascii=False).encode('utf-8')
            #     self.keyboard = str(self.keyboard.decode('utf-8'))
            #     self.write_msg(id=id,
            #                    message=f'{self.client["name"]}  вы хотите записаться к {self.client["spec"]} на {self.client["uslg"]} в {self.client["time"]}?',
            #                    keyboard=self.keyboard, image=None)
            #     self.step = 'agry'
            #
            # elif self.step == 'agry':
            #     upd = raspisanie.get((raspisanie.Специалист == self.client['date']) & (
            #         raspisanie.время.contains(f'2022-09-30 {self.client["time"]}:00')))
            #     upd.клиент = self.client['name']
            #     upd.save()
            #     self.write_msg(id=id, message=f'Вы записаны!!', keyboard=None, image=None)
            #     self.step = None
            #     self.client = self.client = {
            #         "name": '',
            #         'uslg': '',
            #         'spec': '',
            #         'date': '',
            #         'time': '',
            #     }
            #
            # elif self.step == 'rabi':
            #     self.keyboard = {
            #         # "one_time": True,
            #         "buttons": [
            #             [self.get_but('Расписание', 'primary')],
            #             [self.get_but('Назад', 'primary')]],
            #         "inline": True
            #     }
            #     self.keyboard = json.dumps(self.keyboard, ensure_ascii=False).encode('utf-8')
            #     self.keyboard = str(self.keyboard.decode('utf-8'))
            #     rab = rabotniki.get(rabotniki.имя == message)
            #     self.write_msg(id=id, message=f'{rab.имя}\n\nО специалисте: {rab.описание}', keyboard=self.keyboard,
            #                    image=rab.фото)
            #     self.step = rab.id
            #     self.client['spec'] = message
            #     self.client['date'] = rab.id


            else:
                self.keyboard = {
                    # "one_time": True,
                    "buttons": [
                        [self.get_but('Наши Услуги', 'primary', 'uslg')],
                        [self.get_but('Наши Специалисты', 'primary', 'Fspeci')],
                        [self.get_but('О нас', 'secondary', 'info')]

                    ],
                    "inline": True
                }
                self.keyboard = json.dumps(self.keyboard, ensure_ascii=False).encode('utf-8')
                self.keyboard = str(self.keyboard.decode('utf-8'))
                self.write_msg(id=id, message='Здравствуйте привесствуем вас в салоне Эгоист!', keyboard=self.keyboard,
                               image='photo/egoist.png')
                self.talk = True
                # self.write_msg(id=id, message='МЕНЮ', keyboard=self.keyboard,
                #                image=None)






        else:
            print(event.type)


if __name__ == '__main__':
    bot = Bot(TOKEN, GROUP_ID)
    bot.run()

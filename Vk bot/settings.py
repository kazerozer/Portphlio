

INTENTS = [
    {
        "name": "Оскорбления",
        "tokens": ('иди на', 'иди в', 'пошел', 'отсоси', 'пошёл', 'пид'),
        "scenario": None,
        "answer": "И этими губами ты целуешь свою маму?"
    },
    {
        "name": "Приветсвие",
        "tokens": ('привет', 'здарова', 'хай', 'здрав'),
        "scenario": None,
        "answer": "Привет {}, я обычный чат бот, работаю здесь и болтаю со всеми. \n Если хочешь могу рассказать тебе "
                  "Анекдот?. (Напиши: 'Хочу анекдот')\n Или могу показать информацию о интерисующем вас фильме, "
                  "актере. (Напиши: 'Кино') "
    },
    {
        "name": "Дата проведения",
        "tokens": ('когда', 'сколько', 'дата', 'дату'),
        "scenario": None,
        "answer": "Конфа пройдет 15 Октебря, регистрацию можно пройти сейчас"
    },
    {
        "name": "Место проведения",
        "tokens": ('где', 'место', 'локация', 'адрес'),
        "scenario": None,
        "answer": "Екатеринбург ЭКСПО"
    },
    {
        "name": "Регистрация",
        "tokens": ('регист', 'добав', 'запиши'),
        "scenario": "registration",
        "answer": None
    },
    {
        "name": "Кинопоиск",
        "tokens": ('кино', 'фильм'),
        "scenario": "kino",
        "answer": None
    },
    {
        "name": "Анекдот",
        "tokens": ('анекдот', 'расскажи'),
        "scenario": "anekdots",
        "answer": None
    }
]

SCENARIOS = {
    'kino': {
        'first_step': 'step1',
        'steps': {
            'step1': {
                'text': "Введите название фильма, или имя актера",
                'failure_text': 'К сожелению по вашему запросу ничего не найдено, попробуйте ещё раз',
                'handler': 'handler_kino',
                'next_step': 'step2'
            },
            'step2': {
                'text': "{name}\n{year}\n{director}\n{rating}\n"
                        "Ссылка - https://www.kinopoisk.ru{link}",
                'failure_text': '',
                'handler': None,
                'next_step': None
            },
        }
    },
    'anekdots': {
        'first_step': 'step1',
        'steps': {
            'step1': {
                'text': "Готовы смеяться?",
                'failure_text': '',
                'handler': 'handler_anikdot',
                'next_step': 'step2'
            },
            'step2': {
                'text': "{name[0]}",
                'failure_text': None,
                'handler': None,
                'next_step': None
            },
        }
    },
    'registration': {
        'first_step': 'step1',
        'steps': {
            'step1': {
                'text': "Чтобы зарегистрироваться, введите имя. Оно будет напечатоно у вас на жопе!",
                'failure_text': 'Имя должно состоять из 3-30 букв и дефиса. Попробуйте ещё раз!',
                'handler': 'handler_name',
                'next_step': 'step2'
            },
            'step2': {
                'text': "Введите email. Мы отправим на него все данные.",
                'failure_text': 'Во введенном адересе ошибка. Попробуйте ещё раз',
                'handler': 'handler_email',
                'next_step': 'step3'
            },
            'step3': {
                'text': "Спасибо за регистрацию, {name}! Мы отправили на {email} билет, распечатайте его на своём "
                        "принтаре, так как нам жалко свою краску!! ",
                'failure_text': None,
                'handler': None,
                'next_step': None
            },
        }
    }
}

DEFAULT_ANSWER = 'Не могу вас понять (('

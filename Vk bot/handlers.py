import re
import random

from anekdots import anekdots
re_name = re.compile(r'^[\w\-\s]{3,40}$')
re_email = re.compile(r"\b^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+\b")

def handler_kino(text,context):
    import requests
    import lxml.html
    search = text
    search = search.lower()
    search = search.replace(' ', '+')
    url = f'https://www.kinopoisk.ru/index.php?kp_query={search}'
    r = requests.get(url)
    while r.history != []:
        search = search[:-1]
        url = f'https://www.kinopoisk.ru/index.php?kp_query={search}'
        print(url)
        r = requests.get(url)
    html_tree = lxml.html.document_fromstring(r.text)
    list_of_matches = html_tree.xpath('//*[@id="block_left_pad"]/div/div[2]/div/div[2]/p/a')
    if list_of_matches != []:
        if list_of_matches[0].attrib["data-type"] == 'person':
            context['name'] = f'Скорее всего вы ищите актера -{list_of_matches[0].text}'
            context['link'] = list_of_matches[0].attrib["href"]
            img_url = list_of_matches[0].text
            list_of_matches = html_tree.xpath('//*[@class="year"]')
            context['year'] = f'{list_of_matches[0].text} года рождения'
            list_of_matches = html_tree.xpath('//*[@id="block_left_pad"]/div/div[2]/div/div[2]/span[2]')
            prof = list_of_matches[0].text.split('\n')
            prof = prof[1].split('\t')
            context['director'] = f'Професия - {prof[1]} '
            context['rating'] = ''
            url = f'https://yandex.ru/images/search?text={img_url}'
            r = requests.get(url)
            html_tree = lxml.html.document_fromstring(r.text)
            list_of_matches = html_tree.xpath('//*[@class="serp-item__thumb justifier__thumb"]')
            context['img'] = f'https:{list_of_matches[0].attrib["src"]}'
            with open('share_pic.webp', 'wb') as f:
                f.write(requests.get(context['img']).content)

        else:
            context['name'] = f'Скорее всего вы ищите фильм -{list_of_matches[0].text}'
            context['link'] = list_of_matches[0].attrib["href"]
            img_url = list_of_matches[0].text
            list_of_matches = html_tree.xpath('//*[@class="year"]')
            context['year'] = f'{list_of_matches[0].text} года'
            list_of_matches = html_tree.xpath('//*[@class="lined js-serp-metrika"]')
            context['director'] = f'Режиссер - {list_of_matches[0].text}'
            list_of_matches = html_tree.xpath('//*[contains(@class,"rating")]')
            if list_of_matches == []:
                context['rating'] ='Оценки пока что нет'
            else:
                context['rating'] = f'Оценка на кинопоиске: {list_of_matches[0].text}'
            url = f'https://yandex.ru/images/search?text={img_url}%20постер'
            r = requests.get(url)
            html_tree = lxml.html.document_fromstring(r.text)
            list_of_matches = html_tree.xpath('//*[@class="serp-item__thumb justifier__thumb"]')
            context['img'] = f'https:{list_of_matches[0].attrib["src"]}'
            with open('share_pic.webp', 'wb') as f:
                f.write(requests.get(context['img']).content)
        return True
    else:
        return False




def handler_anikdot(text,context):

    context['name'] = random.sample(anekdots, 1)
    return True


def handler_name(text, context):
    match = re.match(re_name, text)
    if match:
        context['name'] = text
        return True
    else:
        return False

def handler_email(text, context):
    matches = re.findall(re_email, text)
    if len(matches) > 0:
        context['email'] = matches[0]
        return True
    else:
        return False



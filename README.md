# Quiz Test
Это выполненное тестовое задание на позицию Unity Junior
Версия Unity 2022.3.25f1

## Описание задания
Тестовое задание на позицию Junior разработчик Unity

Задание:
Вам необходимо создать мобильную игру-квиз в Unity с использованием JSON файла для хранения вопросов и фона для каждого вопроса. В игре должны быть следующие особенности:
1.	Главное меню: экран с кнопкой "Начать игру", которая перенаправляет пользователя на первый вопрос.
2.	Вопросы: для каждого вопроса должен быть уникальный фон и текстовое поле с вопросом. Варианты ответов также должны быть представлены на экране.
3.	Правильный и неправильный ответ: после того, как пользователь выберет ответ, игра должна отобразить экран с сообщением "Верно" или "Неверно". Экран должен также содержать кнопку "Далее", которая перенаправляет пользователя на следующий вопрос.
4.	Результаты: после того, как пользователь ответит на все вопросы, игра должна показать экран с результатами, отображающим количество правильных ответов и кнопкой "Новая игра", которая перенаправляет пользователя на главный экран.
Для реализации данной игры вы можете использовать любые возможности Unity, включая графический интерфейс, скрипты, JSON-файлы и т.д.
JSON-файл для вопросов должен иметь следующую структуру:
Важно! Можно менять количество ответов для вывода(4,3,5 и тд), так же и количество верных ответов, мультивыбор
Игра должна корректно работать на мобильном телефоне андроид
```
jsonCopy code
[
  {
    "question": "Какая страна самая большая в мире?",
    "answers": [
      {"text": "Россия", "correct": true},
      {"text": "США", "correct": false},
      {"text": "Китай", "correct": false},
      {"text": "Канада", "correct": false}
    ],
    "background": "backgrounds/russia.jpg"
  },
  {
    "question": "Какой металл самый тяжелый?",
    "answers": [
      {"text": "Золото", "correct": false},
      {"text": "Платина", "correct": false},
      {"text": "Олово", "correct": false},
      {"text": "Осмий", "correct": true}
    ],
    "background": "backgrounds/osmium.jpg"
  },
  ...
]
```

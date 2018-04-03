<h1>Задание №1:</h1>
Для объектов класса Book (ISBN, автор, название, издательство, год издания, количество страниц, цена) реализовать возможность строкового представления различного вида.
<br>
Например, для объекта со значениями ISBN = 978-0- 7356-6745- 7, AuthorName
= Jeffrey Richter, Title = CLR via C#, Publisher = Microsoft Press, Year = 2012,
NumberOPpages = 826, Price = 59.99$, могут быть следующие варианты:<br>
- Jeffrey Richter, CLR via C#.<br>
- Jeffrey Richter, CLR via C#, Microsoft Press, 2012.<br>
- ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, Microsoft Press, 2012, 826.<br>
- Jeffrey Richter, CLR via C#, Microsoft Press&quot, 2012.<br>
- ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, Microsoft Press, 2012, P. 826., 59.99$.<br>
и т.д.<br>
<a href = "https://github.com/Hamelioniya/NET.S.2018.Galtsova/tree/master/NET.S.2018.Galtsova.08">Перейти</a><br>
<h1>Задание №2:</h1>
Не изменяя класс Book, добавить для объектов данного класса дополнительную возможность форматирования, изначально не предусмотренную классом.<br>
<a href = "https://github.com/Hamelioniya/NET.S.2018.Galtsova/tree/master/NET.S.2018.Galtsova.08">Перейти</a><br>
<h1>Задание №3:</h1>
Для реализованных в заданиях 1, 2 функциональностей разработать модульные тесты.<br>
<a href = "https://github.com/Hamelioniya/NET.S.2018.Galtsova/tree/master/NET.S.2018.Galtsova.08">Перейти</a><br>
<h1>Задание №4:</h1>
Выполнить рефакторинг класса (с целью сокращения повторного кода) в алгоритмах Евклида (для рефакторинга использовать делегаты, рефакторинг возможен только в случае, когда все метод находятся в одном классе!). Интерфейс класса измениться не должен.<br>
<a href = "https://github.com/Hamelioniya/NET.S.2018.Galtsova/tree/master/NET.W.2018.Galtsova.03_04">Перейти</a><br>
<h1>Задание №5:</h1>
В класс с алгоритмом сортировки не прямоугольной матрицы, принимающим как компаратор интерфейс IComparer&lt;int[]&gt; добавить метод, принимающий как параметр делегат-компаратор, инкапсулирующий логику сравнения строк матрицы.<br>
Протестировать работу разработанного метода на примере сортировки матрицы, используя прежние критерии сравнения. Класс реализовать двумя способами, «замкнув» в первом варианте реализацию метода сортировки с делегатом на метод с интерфейсом, во втором – наоборот.<br>
<a href = "https://github.com/Hamelioniya/NET.S.2018.Galtsova/tree/master/NET.S.2018.Galtsova.05">Перейти</a><br>
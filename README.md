# Тестовое задание Digital Design  
## Задание 1  
![изображение](https://github.com/Urvatov/test-digital-design/assets/117490456/9d485d1c-e477-4628-973a-06570b791a1b)  

## Запрос 1 — Выбрать сотрудника с максимальной заработной платой.  

SELECT *
FROM employee
WHERE salary = (SELECT MAX(salary) FROM employee)  
LIMIT 1;  

Данный запрос выбирает все строки из таблицы emplpyee, где зарплата равна максимальной в этой же таблице.  

## Запрос 2 — Вывести одно число: максимальную длину цепочки руководителей по таблице сотрудников (вычислить глубину дерева). 

WITH RECURSIVE ManagerChain AS  
(  
  SELECT id, chief_id, 1 AS depth  
  FROM employee  
  WHERE chief_id IS NULL  
  UNION ALL  
  SELECT e.id, e.chief_id, mc.depth + 1  
  FROM employee e  
  JOIN ManagerChain mc ON e.chief_id = mc.id  
)  
SELECT MAX(depth) AS max_depth  
FROM ManagerChain;  

Данный запрос вычисляет максимальную длину цепочки руководителей в таблице сотрудников, 
начиная с корневых элементов, рекурсивно добавляя подчиненных для каждого выбранного 
корневого элемента, и определяя максимальную глубину этой иерархии, начиная с нулевой глубины. 

## Запрос 3 — Выбрать отдел, с максимальной суммарной зарплатой сотрудников.  

SELECT d.name AS department_name, SUM(e.salary) AS total_salary  
FROM department d  
JOIN employee e ON d.id = e.department_id  
GROUP BY d.name  
ORDER BY total_salary DESC  
LIMIT 1;  

Данный запрос выбирает название отдела и суммарную зарплату всех сотрудников этого отдела, объединяя таблицы employee и department и группируя их по названию. 

## Запрос 4 — Выбрать сотрудника, чье имя начинается на «Р» и заканчивается на «н».

SELECT * FROM employee WHERE name LIKE 'Р%н' LIMIT 1;

Данный запрос выбирает все строки из таблицы employee для сотрудника, имя которое начинается на 'Р' и кончается на 'н'.  


# Задание 2
Напишите консольное приложение на C#, которое на вход принимает большой текстовый файл. На выходе создает текстовый
файл с перечислением всех уникальных слов встречающихся в тесте и количеством их
употреблений, отсортированный в порядке убывания количества употреблений.  

Результат выполнения программы:
![изображение](https://github.com/Urvatov/test-digital-design/assets/117490456/9a038357-95c4-4384-834f-77d60802310a)
![изображение](https://github.com/Urvatov/test-digital-design/assets/117490456/114740fb-42d8-4f46-a4e7-76ca351ee53a)

[Программа](TestApp/bin/Debug/net8.0/TestApp.exe)  
[Код](TestApp/Program.cs)  

[Текст Толстого](TestApp/bin/Debug/net8.0/textfile.txt)  
[Текст Достоевского](TestApp/bin/Debug/net8.0/textfile2.txt)





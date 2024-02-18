# Тестовое задание Digital Design  
![изображение](https://github.com/Urvatov/test-digital-design/assets/117490456/9d485d1c-e477-4628-973a-06570b791a1b)  

## Запрос 1 — Выбрать сотрудника с максимальной заработной платой.  

SELECT *
FROM employee
WHERE salary = (SELECT MAX(salary) FROM employee);  

Данный запрос выбирает все строки из таблицы emplpyee, где зарплата равна максимальной в этой же таблице.  

## Запрос 2 — Вывести одно число: максимальную длину цепочки руководителей по таблице
сотрудников (вычислить глубину дерева). 

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





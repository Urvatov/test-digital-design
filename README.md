# Тестовое задание Digital Design  
![изображение](https://github.com/Urvatov/test-digital-design/assets/117490456/9d485d1c-e477-4628-973a-06570b791a1b)  

## Запрос 1 — Сотрудника с максимальной заработной платой.  

SELECT *
FROM employee
WHERE salary = (SELECT MAX(salary) FROM employee);  

Данный запрос выбирает все строки из таблицы emplpyee, где зарплата равна максимальной в этой же таблице.  




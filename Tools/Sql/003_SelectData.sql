-- Провести выборки клиентов, у которых сумма на счету ниже
-- определенного значения, отсортированных в порядке возрастания суммы
SELECT c.passport_id, c.first_name, c.last_name, a.amount
FROM client c
         JOIN account a ON c.passport_id = a.client_passport_id
WHERE a.amount < 10000
ORDER BY a.amount;

-- Провести поиск клиента с минимальной суммой на счете
SELECT c.passport_id, c.first_name, c.last_name, a.amount
FROM client c
         JOIN account a ON c.passport_id = a.client_passport_id
WHERE a.amount = (SELECT MIN(amount) FROM account);

-- Провести подсчет суммы денег у всех клиентов банка
SELECT SUM(amount)
FROM account;

-- С помощью оператора Join, получить выборку банковских счетов и их владельцев
SELECT c.passport_id, c.first_name, c.last_name, a.amount, a.currency_code
FROM client c
         JOIN account a ON c.passport_id = a.client_passport_id;

-- Вывести клиентов от самых старших к самым младшим
SELECT *
FROM client
ORDER BY birthday;

-- Подсчитать количество человек, у которых одинаковый возраст
SELECT EXTRACT(YEAR FROM AGE(birthday)) AS age, COUNT(*) AS count
FROM client
GROUP BY age
ORDER BY age;

-- Сгруппировать клиентов банка по возрасту
-- Мне кажется, что предыдущий запрос делает то же самое. Если не так - допишу.

-- Вывести только N человек из таблицы
SELECT *
FROM client
LIMIT 10;
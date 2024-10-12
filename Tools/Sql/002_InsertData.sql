INSERT INTO currency (code, name)
VALUES ('USD', 'US Dollar'),
       ('EUR', 'Euro'),
       ('RUB', 'Ruble');

INSERT INTO employee (passport_id, first_name, last_name, middle_name, phone_number, birthday)
VALUES ('pass1', 'Stepan', 'Golub', null, '+37377964029', '2004-08-07 12:21:20.000000'),
       ('pass3', 'Alice', 'Johnson', null, '+37312345678', '2003-11-15 08:30:00.000000'),
       ('pass4', 'Bob', 'Smith', null, '+37387654321', '2002-02-24 14:45:00.000000'),
       ('pass5', 'Charlie', 'Brown', null, '+37355555555', '2001-06-30 09:15:00.000000'),
       ('pass6', 'David', 'Miller', null, '+37311111111', '2004-12-01 11:10:00.000000'),
       ('pass7', 'Eva', 'Davis', null, '+37322222222', '2006-04-17 16:05:00.000000'),
       ('pass8', 'Frank', 'Wilson', null, '+37333333333', '2003-05-22 12:20:00.000000'),
       ('pass9', 'Grace', 'Taylor', null, '+37344444444', '2000-10-10 10:00:00.000000'),
       ('pass10', 'Hannah', 'Anderson', null, '+37366666666', '2005-09-13 17:45:00.000000'),
       ('pass11', 'Ian', 'Thomas', null, '+37377777777', '2002-03-07 13:35:00.000000'),
       ('pass12', 'Jack', 'White', null, '+37388888888', '2004-07-27 18:55:00.000000');

INSERT INTO client (passport_id, first_name, last_name, middle_name, phone_number, birthday)
VALUES ('pass13', 'Karen', 'Robinson', null, '+37399999999', '2003-12-18 09:00:00.000000'),
       ('pass14', 'Leo', 'Martinez', null, '+37311112222', '2001-01-05 11:45:00.000000'),
       ('pass15', 'Mia', 'Clark', null, '+37322223333', '2004-06-08 15:20:00.000000'),
       ('pass16', 'Nathan', 'Rodriguez', null, '+37333334444', '2002-02-28 08:15:00.000000'),
       ('pass17', 'Olivia', 'Lewis', null, '+37344445555', '2006-03-22 19:30:00.000000'),
       ('pass18', 'Peter', 'Walker', null, '+37355556666', '2005-07-14 12:40:00.000000'),
       ('pass19', 'Quinn', 'Hall', null, '+37366667777', '2001-08-31 16:50:00.000000'),
       ('pass20', 'Rachel', 'Allen', null, '+37377778888', '2003-11-11 14:25:00.000000'),
       ('pass21', 'Sam', 'Young', null, '+37388889999', '2000-09-06 10:05:00.000000'),
       ('pass22', 'Tina', 'Hernandez', null, '+37399990000', '2002-05-16 13:10:00.000000')

INSERT INTO account (currency_code, amount, client_passport_id)
VALUES ('USD', 1500, 'pass13'),
       ('EUR', 2500, 'pass14'),
       ('RUB', 50000, 'pass15'),
       ('USD', 3200, 'pass16'),
       ('EUR', 4800, 'pass17'),
       ('RUB', 75000, 'pass18'),
       ('USD', 6100, 'pass19'),
       ('EUR', 2200, 'pass20'),
       ('RUB', 42000, 'pass21'),
       ('USD', 8300, 'pass22'),
       ('EUR', 1300, 'pass13'),
       ('RUB', 60000, 'pass14'),
       ('USD', 7000, 'pass15'),
       ('EUR', 3000, 'pass16'),
       ('RUB', 55000, 'pass17'),
       ('USD', 9400, 'pass18'),
       ('EUR', 2100, 'pass19'),
       ('RUB', 37000, 'pass20'),
       ('USD', 5400, 'pass21'),
       ('EUR', 2700, 'pass22');
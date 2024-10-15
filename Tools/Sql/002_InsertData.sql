INSERT INTO currency (id, code, name)
VALUES (uuid_generate_v4(), 'USD', 'US Dollar'),
       (uuid_generate_v4(), 'EUR', 'Euro'),
       (uuid_generate_v4(), 'RUB', 'Ruble');

INSERT INTO employee (id, passport_id, first_name, last_name, middle_name, phone_number, birthday)
VALUES (uuid_generate_v4(), 'pass1', 'Stepan', 'Golub', null, '+37377964029', '2004-08-07 12:21:20.000000'),
       (uuid_generate_v4(), 'pass3', 'Alice', 'Johnson', null, '+37312345678', '2003-11-15 08:30:00.000000'),
       (uuid_generate_v4(), 'pass4', 'Bob', 'Smith', null, '+37387654321', '2002-02-24 14:45:00.000000'),
       (uuid_generate_v4(), 'pass5', 'Charlie', 'Brown', null, '+37355555555', '2001-06-30 09:15:00.000000'),
       (uuid_generate_v4(), 'pass6', 'David', 'Miller', null, '+37311111111', '2004-12-01 11:10:00.000000'),
       (uuid_generate_v4(), 'pass7', 'Eva', 'Davis', null, '+37322222222', '2006-04-17 16:05:00.000000'),
       (uuid_generate_v4(), 'pass8', 'Frank', 'Wilson', null, '+37333333333', '2003-05-22 12:20:00.000000'),
       (uuid_generate_v4(), 'pass9', 'Grace', 'Taylor', null, '+37344444444', '2000-10-10 10:00:00.000000'),
       (uuid_generate_v4(), 'pass10', 'Hannah', 'Anderson', null, '+37366666666', '2005-09-13 17:45:00.000000'),
       (uuid_generate_v4(), 'pass11', 'Ian', 'Thomas', null, '+37377777777', '2002-03-07 13:35:00.000000'),
       (uuid_generate_v4(), 'pass12', 'Jack', 'White', null, '+37388888888', '2004-07-27 18:55:00.000000');

INSERT INTO client (id, passport_id, first_name, last_name, middle_name, phone_number, birthday)
VALUES (uuid_generate_v4(), 'pass13', 'Karen', 'Robinson', null, '+37399999999', '2003-12-18 09:00:00.000000'),
       (uuid_generate_v4(), 'pass14', 'Leo', 'Martinez', null, '+37311112222', '2001-01-05 11:45:00.000000'),
       (uuid_generate_v4(), 'pass15', 'Mia', 'Clark', null, '+37322223333', '2004-06-08 15:20:00.000000'),
       (uuid_generate_v4(), 'pass16', 'Nathan', 'Rodriguez', null, '+37333334444', '2002-02-28 08:15:00.000000'),
       (uuid_generate_v4(), 'pass17', 'Olivia', 'Lewis', null, '+37344445555', '2006-03-22 19:30:00.000000'),
       (uuid_generate_v4(), 'pass18', 'Peter', 'Walker', null, '+37355556666', '2005-07-14 12:40:00.000000'),
       (uuid_generate_v4(), 'pass19', 'Quinn', 'Hall', null, '+37366667777', '2001-08-31 16:50:00.000000'),
       (uuid_generate_v4(), 'pass20', 'Rachel', 'Allen', null, '+37377778888', '2003-11-11 14:25:00.000000'),
       (uuid_generate_v4(), 'pass21', 'Sam', 'Young', null, '+37388889999', '2000-09-06 10:05:00.000000'),
       (uuid_generate_v4(), 'pass22', 'Tina', 'Hernandez', null, '+37399990000', '2002-05-16 13:10:00.000000');



INSERT INTO account (client_id, currency_id, amount)
VALUES ('b7e5cf23-0f78-4829-9c3a-c819164f3702', '13589ffd-e747-45ae-9d01-4fa5aebcc3ff', 1500),
       ('92b7fe08-b559-45c9-9979-b0b66e0730a0', '1a4ccf5b-13ee-4263-ac09-be677fe0fd6b', 2500),
       ('bfbf9b44-f433-4ce7-bfe8-83f0c5fb2908', '7e158e37-ec60-4988-b88f-80b7e1b7cd70', 50000),
       ('7f633036-fb61-4fe8-9a73-486a0b9c9635', '13589ffd-e747-45ae-9d01-4fa5aebcc3ff', 3200),
       ('bd1f452b-472a-4045-9516-ef96e2f7f9c0', '1a4ccf5b-13ee-4263-ac09-be677fe0fd6b', 4800),
       ('44431c64-a5a5-4382-bb63-f05e0a6e1da6', '7e158e37-ec60-4988-b88f-80b7e1b7cd70', 75000),
       ('c4eeb157-b323-41ca-9eba-44abf8125c49', '13589ffd-e747-45ae-9d01-4fa5aebcc3ff', 6100),
       ('090a151a-f5e7-47ae-b93b-f4f6fe0d86a6', '1a4ccf5b-13ee-4263-ac09-be677fe0fd6b', 2200),
       ('fb00cf1d-d803-4890-b7fe-119293dd4df3', '7e158e37-ec60-4988-b88f-80b7e1b7cd70', 42000),
       ('8fc2f76c-e0f4-4d23-b027-b3207b278a96', '13589ffd-e747-45ae-9d01-4fa5aebcc3ff', 8300),
       ('b7e5cf23-0f78-4829-9c3a-c819164f3702', '1a4ccf5b-13ee-4263-ac09-be677fe0fd6b', 1300),
       ('92b7fe08-b559-45c9-9979-b0b66e0730a0', '7e158e37-ec60-4988-b88f-80b7e1b7cd70', 60000),
       ('bfbf9b44-f433-4ce7-bfe8-83f0c5fb2908', '13589ffd-e747-45ae-9d01-4fa5aebcc3ff', 7000),
       ('7f633036-fb61-4fe8-9a73-486a0b9c9635', '1a4ccf5b-13ee-4263-ac09-be677fe0fd6b', 3000),
       ('bd1f452b-472a-4045-9516-ef96e2f7f9c0', '7e158e37-ec60-4988-b88f-80b7e1b7cd70', 55000),
       ('44431c64-a5a5-4382-bb63-f05e0a6e1da6', '13589ffd-e747-45ae-9d01-4fa5aebcc3ff', 9400),
       ('c4eeb157-b323-41ca-9eba-44abf8125c49', '1a4ccf5b-13ee-4263-ac09-be677fe0fd6b', 2100),
       ('090a151a-f5e7-47ae-b93b-f4f6fe0d86a6', '7e158e37-ec60-4988-b88f-80b7e1b7cd70', 37000),
       ('fb00cf1d-d803-4890-b7fe-119293dd4df3', '13589ffd-e747-45ae-9d01-4fa5aebcc3ff', 5400),
       ('8fc2f76c-e0f4-4d23-b027-b3207b278a96', '1a4ccf5b-13ee-4263-ac09-be677fe0fd6b', 2700);

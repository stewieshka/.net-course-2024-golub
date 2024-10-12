create table if not exists client
(
    passport_id  text
        constraint client_pk
            primary key,
    first_name   text      not null,
    last_name    text      not null,
    middle_name  text,
    phone_number text      not null,
    birthday     timestamp not null
);

create table if not exists employee
(
    passport_id  text
        constraint employee_pk
            primary key,
    first_name   text      not null,
    last_name    text      not null,
    middle_name  text,
    phone_number text      not null,
    birthday     timestamp not null
);

create table if not exists currency
(
    code varchar(3) not null
        constraint currency_pk
            primary key,
    name text       not null
);

create table if not exists account
(
    currency_code      varchar(3) not null
        constraint account_currency_code_fk
            references currency,
    amount             integer    not null,
    client_passport_id text       not null
        constraint account_client_passport_id_fk
            references client
);
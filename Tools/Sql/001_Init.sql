create table if not exists client
(
    id           uuid
        constraint client_pk
            primary key,
    passport_id  text      not null,
    first_name   text      not null,
    last_name    text      not null,
    middle_name  text,
    phone_number text      not null,
    birthday     timestamp not null
);

create table if not exists employee
(
    id           uuid
        constraint employee_pk
            primary key,
    passport_id  text      not null,
    first_name   text      not null,
    last_name    text      not null,
    middle_name  text,
    phone_number text      not null,
    birthday     timestamp not null
);

create table if not exists currency
(
    id   uuid
        constraint currency_pk
            primary key,
    code varchar(3) not null,
    name text       not null
);

create table if not exists account
(
    currency_id uuid    not null
        constraint account_currency_id_fk
            references currency,
    amount      decimal not null,
    client_id   uuid    not null
        constraint account_client_id_fk
            references client
);
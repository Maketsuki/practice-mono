CREATE TABLE IF NOT EXISTS thing
(
    id                  UUID PRIMARY KEY,
    name                VARCHAR                     NOT NULL,
    occupation          VARCHAR(320)                NOT NULL,
    age                 INTEGER                     NOT NULL,
    created_date        TIMESTAMP WITH TIME ZONE    NOT NULL,
    modified_date       TIMESTAMP WITH TIME ZONE    NOT NULL
);
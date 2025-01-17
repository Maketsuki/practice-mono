CREATE USER "microservice-template-admin"
    WITH ENCRYPTED PASSWORD 'Asdf!234';

CREATE DATABASE "template-database"
    WITH
    OWNER = "microservice-template-admin"
    ENCODING = 'UTF8'
    LC_COLLATE = 'English_Finland.1252'
    LC_CTYPE = 'English_Finland.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

GRANT ALL PRIVILEGES ON DATABASE "template-database"
    TO "microservice-template-admin";
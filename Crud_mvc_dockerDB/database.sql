CREATE DATABASE testdb;
USE testdb;

CREATE TABLE users (
    id INT IDENTITY(1,1) NOT NULL,
    name NVARCHAR(50),
    email NVARCHAR(255),
    CONSTRAINT PK_User PRIMARY KEY(id)
);
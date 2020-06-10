CREATE USER admin IDENTIFIED BY admin;
GRANT DBA TO admin;


CREATE TABLE users (
    id NUMBER(8,0),
    name VARCHAR(50),
    email VARCHAR(255),
    CONSTRAINT PK_User PRIMARY KEY(id)
);

CREATE SEQUENCE users_id_seq START WITH 1;
CREATE OR REPLACE TRIGGER users_tr
    BEFORE INSERT ON users
    FOR EACH ROW
BEGIN
    SELECT users_id_seq.nextval
    INTO:new.id
    FROM   dual;
END;

INSERT INTO users(name, email) VALUES('Eddy', 'edd@gmail.com');

SELECT * FROM users;
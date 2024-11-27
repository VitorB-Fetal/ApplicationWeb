CREATE DATABASE GreenLifeDB;

USE GreenLifeDB;



CREATE TABLE Nichos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL
);


CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(150) NOT NULL,
    Email NVARCHAR(150) NOT NULL UNIQUE,
    Telefone NVARCHAR(20),
    Foto NVARCHAR(255), 
    NichoId INT NOT NULL,
    Senha NVARCHAR(255) NOT NULL, 
    CpfCnpj NVARCHAR(18) NOT NULL UNIQUE, 
    DataCriacao DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (NichoId) REFERENCES Nichos(Id)
);

INSERT INTO Nichos (Nome) VALUES ('Tecnologia');
INSERT INTO Nichos (Nome) VALUES ('Saúde');
INSERT INTO Nichos (Nome) VALUES ('Educação');
INSERT INTO Nichos (Nome) VALUES ('Marketing');
INSERT INTO Nichos (Nome) VALUES ('Outros');


SELECT * FROM Nichos;
SELECT * FROM Usuarios;

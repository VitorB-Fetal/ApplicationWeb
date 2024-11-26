CREATE DATABASE GreenLifeDB;

USE GreenLifeDB;


-- Criar a tabela de Nichos (Nicho de Trabalho)
CREATE TABLE Nichos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL
);

-- Criar a tabela de Usuários
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(150) NOT NULL,
    Email NVARCHAR(150) NOT NULL UNIQUE,
    Telefone NVARCHAR(20),
    Foto NVARCHAR(255), -- Caminho ou URL da foto
    NichoId INT NOT NULL,
    Senha NVARCHAR(255) NOT NULL, -- Senha deve ser hash no aplicativo
    CpfCnpj NVARCHAR(18) NOT NULL UNIQUE, -- Validação de CPF ou CNPJ
    DataCriacao DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (NichoId) REFERENCES Nichos(Id)
);

-- Inserir Nichos de Trabalho padrão
INSERT INTO Nichos (Nome) VALUES ('Tecnologia');
INSERT INTO Nichos (Nome) VALUES ('Saúde');
INSERT INTO Nichos (Nome) VALUES ('Educação');
INSERT INTO Nichos (Nome) VALUES ('Marketing');
INSERT INTO Nichos (Nome) VALUES ('Outros');

-- Exemplo de exibição das tabelas criadas
SELECT * FROM Nichos;
SELECT * FROM Usuarios;

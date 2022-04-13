CREATE DATABASE [db-gp11];
GO

USE [db-gp11];
GO

-- TIPO USUARIO
CREATE TABLE tipoUsuario(
	idTipoUsuario INT PRIMARY KEY IDENTITY,
	tipoUsuario VARCHAR(20) UNIQUE NOT NULL
);
GO

SELECT * FROM tipoUsuario
GO;

-- USUARIO
CREATE TABLE usuarios (
	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
	nomeUsuario VARCHAR(50) NOT NULL,
	email VARCHAR(70) UNIQUE NOT NULL,
	senha VARCHAR(100) NOT NULL,
	dataNascimento DATE NOT NULL,
	cpf CHAR(11) UNIQUE NOT NULL,
	pontos INT DEFAULT 0,
	saldo SMALLMONEY DEFAULT 0.00,
	imagem VARCHAR(235)
);
GO


SELECT * FROM usuarios
GO;

-- BICICLETARIOS 
CREATE TABLE bicicletarios(
	idBicicletario INT PRIMARY KEY IDENTITY,
	nome VARCHAR(60) NOT NULL,
	rua VARCHAR(50) NOT NULL,
	numero INT,
	bairro VARCHAR(20) NOT NULL,
	cidade VARCHAR(40) NOT NULL,
	longitude VARCHAR(10),
	latitude VARCHAR(10),
	cep VARCHAR(10) NOT NULL,
	horarioAberto TIME,
	horarioFechado TIME,
);
GO

SELECT * FROM bicicletarios
GO;

-- VAGAS
CREATE TABLE vagas(
	idVaga INT PRIMARY KEY IDENTITY,
	idBicicletario INT FOREIGN KEY REFERENCES bicicletarios(idBicicletario),
	statusVaga BIT DEFAULT 0
);
GO

SELECT * FROM vagas
GO;

-- RESERVAS
CREATE TABLE reservas(
	idReserva INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES usuarios(idUsuario),
	idVaga INT FOREIGN KEY REFERENCES vagas(idVaga),
	abreTrava DATETIME,
	fechaTrava DATETIME,
	preco SMALLMONEY DEFAULT '0,00',
	statusPagamento BIT DEFAULT 0
);
GO


SELECT * FROM reservas
GO;



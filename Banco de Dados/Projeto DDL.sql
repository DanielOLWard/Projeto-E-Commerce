USE ECommerce -- Troca para o banco "certo"

-- Linguagem SQL
-- SQL - Structured Query Language (Linguagem de Consulta Estruturada)

-- SQL - Comandos

-- DDL (Data Definition Language) <-> Criar, Alterar ou Apagar bancos de dados e tabelas
-- CREATE <-> Cria Banco de Dados ou tabela
-- DROP <-> Apaga o Banco de Dados ou tabela
-- ALTER <-> Altera o Banco de dados ou tabela

-- DML (Data Manipulation Language) <-> Criar, Alterar ou Apagar dados

-- DQL (Data Query Language) <-> Ver os dados


CREATE TABLE Cliente (
-- PRIMARY KEY <-> Coluna que identifica os clientes
-- IDENTITY <-> Gera a sequencia dos clientes automaticamente
	IdCliente INT PRIMARY KEY IDENTITY,
	NomeCompleto VARCHAR(150) NOT NULL, -- NOT NULL, o dado nao pode ser nulo
	EMail VARCHAR (100) NOT NULL UNIQUE,   -- UNIQUE, o dado nao poder te outro igual
	Senha VARCHAR (255) NOT NULL,
	Telefone VARCHAR (20),
	Endereco VARCHAR (255),
	DataCadatro DATE
);
GO

CREATE TABLE Pedido (
	IdPedido INT PRIMARY KEY IDENTITY,
	DataPedido DATE NOT NULL,
	StatusPedido VARCHAR (20) NOT NULL,
	ValorTotal DECIMAL (18, 6),
	IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente) NOT NULL
);
GO

CREATE TABLE Pagamento (
	IdPagamento INT PRIMARY KEY IDENTITY,
	FormaPagamento VARCHAR (30) NOT NULL,
	StatusPagamento VARCHAR (20) NOT NULL,
	DataPagamento DATETIME NOT NULL,
	IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido)
);
GO

CREATE TABLE Produto (
	IdProduto INT PRIMARY KEY IDENTITY,
	NomeProduto VARCHAR (100) NOT NULL,
	Descricao VARCHAR (255),
	Preco DECIMAL (18,6) NOT NULL,
	QtdEstoque INT NOT NULL,
	Categoria VARCHAR (100) NOT NULL,
	Imagem VARCHAR (255)
);
GO

CREATE TABLE ItemPedido (
	IdItemPedido INT PRIMARY KEY IDENTITY,
	Quantidade INT NOT NULL,
	IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido) NOT NULL,
	IdProduto INT FOREIGN KEY REFERENCES Produto(IdProduto) NOT NULL
);
GO

DROP TABLE ItemPedido;
DROP TABLE Pagamento;
DROP TABLE Pedido;
DROP TABLE Produto;
DROP TABLE Cliente;
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
	NomeCompleto VARCHAR(150),
	EMail VARCHAR (100),
	Telefone VARCHAR (20),
	Endereco VARCHAR (255),
	DataCadatro DATE
);

CREATE TABLE Pedido (
	IdPedido INT PRIMARY KEY IDENTITY,
	DataPedido DATE,
	StatusPedido VARCHAR (20),
	ValorTotal DECIMAL (18, 6),
	IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente)
);

CREATE TABLE Pagamento (
	IdPagamento INT PRIMARY KEY IDENTITY,
	FormaPagamento VARCHAR (30),
	StatusPagamento VARCHAR (20),
	DataPagamento DATETIME,
	IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido)
);

CREATE TABLE Produto (
	IdProduto INT PRIMARY KEY IDENTITY,
	NomeProduto VARCHAR (100),
	Descricao VARCHAR (255),
	Preco DECIMAL (18,6),
	QtdEstoque INT,
	Categoria VARCHAR (100),
	Imagem VARCHAR (255)
);

CREATE TABLE ItemPedido (
	IdItemPedido INT PRIMARY KEY IDENTITY,
	Quantidade INT,
	IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido),
	IdProduto INT FOREIGN KEY REFERENCES Produto(IdProduto)
);

DROP TABLE ItemPedido;
DROP TABLE Pagamento;
DROP TABLE Pedido;
DROP TABLE Produto;
DROP TABLE Cliente;
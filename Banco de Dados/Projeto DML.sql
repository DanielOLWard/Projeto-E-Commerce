USE ECommerce;-- DML <-> Inserir, Alterar ou apagar dados
-- INSERT INTO <-> Inserir dados

INSERT INTO Produto (NomeProduto, Descricao, Preco, QtdEstoque, Categoria, Imagem)
VALUES
('Mouse', 'Mouse Logitech', 99.90, 50, 'Informatica', ''),
('Teclado', 'Teclado Dell', 209.50, 100, 'Informatica', '')

INSERT INTO Cliente (NomeCompleto, EMail, Telefone, Endereco, DataCadatro)
VALUES
('Daniel Oliveira', 'daniel@gmail.com', '(11)912341234', 'Estrada ficticia, 356 - Sao Paulo/SP', '05/04/2025'),
('Fulano Teste', 'fulano@gmail.com', '(11)943214321', 'Estrada ficticia, 457358 - Sao Paulo/SP', '21/09/2025');

INSERT INTO Pedido ( IdCliente, DataPedido, StatusPedido, ValorTotal)
VALUES
(1, '05/09/2021', 'Recusado', 4578.99),
(2, '28/02/2022', 'Aprovado', 50.30)

INSERT INTO Pagamento (IdPedido, FormaPagamento, StatusPagamento, DataPagamento)
VALUES
(3, 'PIX', 'Estornado', '07/02/1999 07:59:59'),
(4, 'Dinheiro', 'Concluido', '29/04/2009 08:36:55')

INSERT INTO ItemPedido(IdPedido, IdProduto, Quantidade)
VALUES
(3, 1, 5),
(4, 2, 6)

-- NAO USAR SEM O "WHERE"
DELETE FROM Cliente WHERE NomeCompleto = 'Fulano Teste';

-- DQL <-> Visualizar os dados

-- SELECT

SELECT * FROM Cliente;
SELECT * FROM ItemPedido;
SELECT * FROM Pagamento;
SELECT * FROM Pedido;
SELECT * FROM Produto;
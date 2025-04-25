using System.Collections.Concurrent;
using E_Commerce_API.Context;
using E_Commerce_API.DTO;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;

namespace E_Commerce_API.Repositories
{
    // 1 - Herdar a interface
    // 2 - Implementar a interface
    // 3 - Injetar o contexto
    public class ProdutoRepository : IProdutoRepository
    {
        // Metodos que acessam o BD

        // Injetar o Context
        // Injecao de Dependencia
        private readonly EcommerceContext _context;

        // ctor <Atalho para criar o metodo abaixo>
        // Metodo construtor - Metodo que tem o mesmo nome da classe
        public ProdutoRepository(EcommerceContext context) 
        {
            _context = context;
        }

        public void Atualizar(int id, CadastrarProdutoDTO produto)
        {
            // Encontro o produto que desejo atualizar
            Produto produtoEncontrado = _context.Produtos.Find(id);

            // Tratamento de erro
            if (produtoEncontrado == null)
            {
                throw new Exception();
            }

            // Muda os dados um por um
            produtoEncontrado.NomeProduto = produto.NomeProduto;
            produtoEncontrado.Descricao = produto.Descricao;
            produtoEncontrado.Preco = produto.Preco;
            produtoEncontrado.Categoria = produto.Categoria;
            produtoEncontrado.Imagem = produto.Imagem;
            produtoEncontrado.QtdEstoque = produto.QtdEstoque;

            _context.SaveChanges(); // Sempre colocar o SaveChanges quando for mudar algo no Banco de Dados
        }

        public Produto BuscarPorId(int id)
        {
            // FirstorDefault - Traz o primeiro que encontrar ou null <nada> (melhor para filtrar)
            return _context.Produtos.FirstOrDefault(p => p.IdProduto == id); // Acessa a tabela, pega o primeiro que encontrar, me retorne aquele que tem o IdProduto igual ao id
        }

        public void Cadastrar(CadastrarProdutoDTO dto)
        {
            Produto produtoCadastro = new Produto
            {
                NomeProduto = dto.NomeProduto,
                Descricao = dto.Descricao,
                Preco = dto.Preco,
                QtdEstoque = dto.QtdEstoque,
                Categoria = dto.Categoria,
                Imagem = dto.Imagem,
            };
            _context.Produtos.Add(produtoCadastro);

            _context.SaveChanges(); // Sempre colocar o SaveChanges quando for mudar algo no Banco de Dados
        }

        public void Deletar(int id)
        {
            // 1 - encontrar o que eu quero excluir
            Produto produtoEncontrado = _context.Produtos.Find(id); // Find - Procura apenas pela chave primaria

            // Tratamento de erro
            if (produtoEncontrado == null)
            {
                throw new Exception();
            }

            // 2 - Caso eu enconte o produto, removo ele
            _context.Produtos.Remove(produtoEncontrado);

            // 3 - Salvo as alteracoes
            _context.SaveChanges();
        }

        public List<Produto> ListarTodos()
        {
            // ToList() - Lista varios
            return _context.Produtos.ToList();
        }
    }
}

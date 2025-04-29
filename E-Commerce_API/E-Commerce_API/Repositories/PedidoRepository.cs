using E_Commerce_API.Context;
using E_Commerce_API.DTO;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using E_Commerce_API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Repositories
{
    // 1 - Herdar a interface
    // 2 - Implementar a interface
    // 3 - Injetar o contexto
    public class PedidoRepository : IPedidoRepository
    {
        // Injetar o Context
        // Injecao de Dependencia
        private readonly EcommerceContext _context;

        // ctor <Atalho para criar o metodo abaixo>
        // Metodo construtor - Metodo que tem o mesmo nome da classe
        public PedidoRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, CadastrarPedidoDTO pedidoDTO)
        {
            // Encontro o pedido que desejo atualizar
            Pedido pedidoEncontrado = _context.Pedidos.Find(id);

            // Tratamento de erro
            if (pedidoEncontrado == null)
            {
                throw new ArgumentNullException();
            }

            // Crio a variavel pedido para guardar as informacoes do Peiddo
            pedidoEncontrado = new Pedido
            {
                DataPedido = pedidoDTO.DataPedido,
                StatusPedido = pedidoDTO.StatusPedido,
                IdCliente = pedidoDTO.IdCliente,
                ValorTotal = pedidoDTO.ValorTotal
            };

            _context.Pedidos.Add(pedidoEncontrado); // Salva o Pedido no Banco de Dados

            _context.SaveChanges(); // Sempre colocar o SaveChanges quando for mudar algo no Banco de Dados

            // Atualizo os ItensPedido
            // para cada Produto, eu Crio um ItemPedido
            for (int i = 0; i < pedidoDTO.Produtos.Count; i++)
            {
                var produtoEncontrado = _context.Produtos.Find(pedidoDTO.Produtos[i]); // Procuro o Produto atual
                // TODO: Lancar erro se produto nao existe

                // Crio uma variavel para guardar as informacoes do ItemPedido
                var itemPedido = new ItemPedido
                {
                    IdPedido = pedidoEncontrado.IdPedido,
                    IdProduto = produtoEncontrado.IdProduto,
                    Quantidade = 0
                };
                _context.ItemPedidos.Add(itemPedido); // Salva o ItemPedido no Banco de Dados

                _context.SaveChanges(); // Sempre colocar o SaveChanges quando for mudar algo no Banco de Dados
            }
        }

        // Cadastrar Pedido
        public void Cadastrar(CadastrarPedidoDTO pedidoDTO)
        {
            // Crio a variavel pedido para guardar as informacoes do Peiddo
            var pedido = new Pedido
            {
                DataPedido = pedidoDTO.DataPedido,
                StatusPedido = pedidoDTO.StatusPedido,
                IdCliente = pedidoDTO.IdCliente,
                ValorTotal = pedidoDTO.ValorTotal
            };

            _context.Pedidos.Add(pedido); // Salva o Pedido no Banco de Dados

            _context.SaveChanges(); // Sempre colocar o SaveChanges quando for mudar algo no Banco de Dados

            // Cadastrar os ItensPedido
            // para cada Produto, eu Crio um ItemPedido
            for (int i = 0; i < pedidoDTO.Produtos.Count; i++)
            {
                var produto = _context.Produtos.Find(pedidoDTO.Produtos[i]); // Procuro o Produto atual
                /*
                if (pedidoDTO != null)
                {
                    throw new ArgumentNullException();
                }
                */
                // Crio uma variavel para guardar as informacoes do ItemPedido
                var itemPedido = new ItemPedido
                {
                    IdPedido = pedido.IdPedido,
                    IdProduto = produto.IdProduto,
                    Quantidade = 0
                };
                _context.ItemPedidos.Add(itemPedido); // Salva o ItemPedido no Banco de Dados

                _context.SaveChanges(); // Sempre colocar o SaveChanges quando for mudar algo no Banco de Dados
            }
        }

        public ListarPedidoViewModel BuscarPorId(int id)
        {
            return _context.Pedidos
                .Select(p => new ListarPedidoViewModel
                {
                    IdPedido = p.IdPedido,
                    DataPedido = p.DataPedido,
                    StatusPedido = p.StatusPedido,
                    ValorTotal = p.ValorTotal,
                    IdCliente = p.IdCliente,
                    ItemPedidos = p.ItemPedidos
                })
                .FirstOrDefault(p => p.IdPedido == id);
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ListarTodos()
        {
            return _context.Pedidos
                .Include(p => p.ItemPedidos)
                .ThenInclude(p => p.IdProdutoNavigation)
                .ToList();
        }
    }
}

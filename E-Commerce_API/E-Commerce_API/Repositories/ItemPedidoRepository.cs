using E_Commerce_API.Context;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;

namespace E_Commerce_API.Repositories
{
    // 1 - Herdar a interface
    // 2 - Implementar a interface
    // 3 - Injetar o contexto
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        // Injetar o Context
        // Injecao de Dependencia
        public readonly EcommerceContext _context;

        // ctor <Cria o metodo abaixo>
        // Metodo construtor
        public ItemPedidoRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, ItemPedido itemPeido)
        {
            throw new NotImplementedException();
        }

        public ItemPedido BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ItemPedido itemPedido)
        {
            _context.ItemPedidos.Add(itemPedido);
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<ItemPedido> ListarTodos()
        {
            return _context.ItemPedidos.ToList();
        }
    }
}

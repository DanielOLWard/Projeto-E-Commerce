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

        // ctor <Atalho para criar o metodo abaixo>
        // Metodo construtor - Metodo que tem o mesmo nome da classe
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

            _context.SaveChanges(); // Sempre colocar o SaveChanges quando for mudar algo no Banco de Dados
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

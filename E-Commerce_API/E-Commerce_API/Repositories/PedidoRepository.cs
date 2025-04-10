using E_Commerce_API.Context;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;

namespace E_Commerce_API.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly EcommerceContext _context;

        public PedidoRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public Pedido BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ListarTodos()
        {
            return _context.Pedidos.ToList();
        }
    }
}

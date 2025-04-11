using E_Commerce_API.Models;

namespace E_Commerce_API.Interfaces
{
    public interface IPedidoRepository
    {
        // R - Read (leitura)
        List<Pedido> ListarTodos();

        Pedido BuscarPorId(int id);

        void Cadastrar(Pedido pedido);

        void Atualizar(int id, Pedido pedido);

        void Deletar(int id);
    }
}

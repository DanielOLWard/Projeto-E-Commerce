using E_Commerce_API.DTO;
using E_Commerce_API.Models;
using E_Commerce_API.ViewModels;

namespace E_Commerce_API.Interfaces
{
    public interface IPedidoRepository
    {
        // R - Read (leitura)
        List<Pedido> ListarTodos(); //Recebe um identificador, e retorna o pedido correspondente

        Pedido BuscarPorId(int id);

        // C - Create (Cadastrar)
        void Cadastrar(CadastrarPedidoDTO pedido);

        // U - Update (Atualizacao)
        // Recbe um identificador, e recebe um pedido novo para ficar no lugar do antigo
        void Atualizar(int id, CadastrarPedidoDTO pedido);

        // D - Delete (Delecao)
        // Recebo o identificador de quem quero excluir
        void Deletar(int id);
    }
}

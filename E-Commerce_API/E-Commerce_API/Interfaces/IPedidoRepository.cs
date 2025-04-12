using E_Commerce_API.Models;

namespace E_Commerce_API.Interfaces
{
    public interface IPedidoRepository
    {
        // R - Read (leitura)
        List<Pedido> ListarTodos(); //Recebe um identificador, e retorna o produto correspondente

        Pedido BuscarPorId(int id);

        // C - Create (Cadastrar)
        void Cadastrar(Pedido pedido);

        // U - Update (Atualizacao)
        // Recbe um identificador, e recebe um produto novo para ficar no lugar do antigo
        void Atualizar(int id, Pedido pedido);

        // D - Delete (Delecao)
        // Recebo o identificador de quem quero excluir
        void Deletar(int id);
    }
}

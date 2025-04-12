using E_Commerce_API.Models;

namespace E_Commerce_API.Interfaces
{
    public interface IItemPedidoRepository
    {
        // R - Read (leitura)
        List<ItemPedido> ListarTodos(); //Recebe um identificador, e retorna o produto correspondente

        ItemPedido BuscarPorId(int id);

        // C - Create (Cadastrar)
        void Cadastrar(ItemPedido itemPedido);

        // U - Update (Atualizacao)
        // Recbe um identificador, e recebe um produto novo para ficar no lugar do antigo
        void Atualizar(int id, ItemPedido itemPeido);

        // D - Delete (Delecao)
        // Recebo o identificador de quem quero excluir
        void Deletar(int id);
    }
}

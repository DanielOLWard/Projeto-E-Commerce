using E_Commerce_API.Models;

namespace E_Commerce_API.Interfaces
{
    public interface IProdutoRepository
    {
        // R - Read (leitura)
        List<Produto> ListarTodos();

        Produto BuscarPorId(int id); //Recebe um identificador, e retorna o produto correspondente

        // C - Create (Cadastrar)
        void Cadastrar(Produto produto);

        // U - Update (Atualizacao)
        // Recbe um identificador, e recebe um produto novo para ficar no lugar do antigo
        void Atualizar(int id, Produto produto);

        // D - Delete (Delecao)
        // Recebo o identificador de quem quero excluir
        void Deletar(int id);
    }
}

using E_Commerce_API.Models;

namespace E_Commerce_API.Interfaces
{
    public interface IPagamentoRepository
    {
        // R - Read (leitura)
        List<Pagamento> ListarTodos(); //Recebe um identificador, e retorna o produto correspondente

        Pagamento BuscarPorId(int id);

        // C - Create (Cadastrar)
        void Cadastrar(Pagamento pagamento);

        // U - Update (Atualizacao)
        // Recbe um identificador, e recebe um produto novo para ficar no lugar do antigo
        void Atualizar(int id, Pagamento pagamento);

        // D - Delete (Delecao)
        // Recebo o identificador de quem quero excluir
        void Deletar(int id);
    }
}

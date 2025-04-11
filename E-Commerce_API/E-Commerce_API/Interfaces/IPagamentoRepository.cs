using E_Commerce_API.Models;

namespace E_Commerce_API.Interfaces
{
    public interface IPagamentoRepository
    {
        // R - Read (leitura)
        List<Pagamento> ListarTodos();

        Pagamento BuscarPorId(int id);

        void Cadastrar(Pagamento pagamento);

        void Atualizar(int id, Pagamento pagamento);

        void Deletar(int id);
    }
}

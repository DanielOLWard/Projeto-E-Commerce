using E_Commerce_API.DTO;
using E_Commerce_API.Models;

namespace E_Commerce_API.Interfaces
{
    public interface IClienteRepository
    {
        // R - Read (leitura)
        List<Cliente> ListarTodos(); //Recebe um identificador, e retorna o produto correspondente

        Cliente BuscarPorId(int id);

        Cliente BuscarPorEmailSenha(string email, string senha);

        // C - Create (Cadastrar)
        void Cadastrar(CadastrarClienteDTO cliente);

        // U - Update (Atualizacao)
        // Recbe um identificador, e recebe um produto novo para ficar no lugar do antigo
        void Atualizar (int id, CadastrarClienteDTO cliente);

        // D - Delete (Delecao)
        // Recebo o identificador de quem quero excluir
        void Deletar(int id);

        List<Cliente> BuscarPorNome(string nome);
    }
}

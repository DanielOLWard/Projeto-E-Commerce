using E_Commerce_API.Models;

namespace E_Commerce_API.Interfaces
{
    public interface IClienteRepository
    {
        // R - Read (leitura)
        List<Cliente> ListarTodos();

        Cliente BuscarPorId(int id);

        Cliente BuscarPorEmailSenha(string email, string senha);

        void Cadastrar(Cliente cliente);   

        void Atualizar (int id, Cliente cliente);

        void Deletar(int id);
    }
}

using E_Commerce_API.DTO;
using E_Commerce_API.Models;
using E_Commerce_API.ViewModels;

namespace E_Commerce_API.Interfaces
{
    public interface IClienteRepository
    {
        // R - Read (leitura)
        List<ListarClienteViewModel> ListarTodos(); //Recebe um identificador, e retorna o produto correspondente

        // Busca o Cliente pelo Id
        ListarClienteViewModel BuscarPorId(int id);

        // Busca o Cliente pelo Email e Senha para realizar o Login
        Cliente BuscarPorEmailSenha(string email, string senha);

        // C - Create (Cadastrar)
        void Cadastrar(CadastrarClienteDTO cliente);

        // U - Update (Atualizacao)
        // Recbe um identificador, e recebe um produto novo para ficar no lugar do antigo
        void Atualizar (int id, CadastrarClienteDTO cliente);

        // D - Delete (Delecao)
        // Recebo o identificador de quem quero excluir
        void Deletar(int id);

        // Busca por Nome Exato
        List<ListarClienteViewModel> BuscarPorNome(string nome);

        // Orderna os Clientes em Ordem alfabetica
        List<ListarClienteViewModel> OrdenarAlfabeticamente(string nome);

        // Busca o nome Parcialmente
        List<ListarClienteViewModel> BuscarNomeParcial(string nomeParcial);
    }
}

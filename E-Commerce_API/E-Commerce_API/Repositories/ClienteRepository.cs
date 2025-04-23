using System.Numerics;
using E_Commerce_API.Context;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;

namespace E_Commerce_API.Repositories
{
    // 1 - Herdar a interface
    // 2 - Implementar a interface
    // 3 - Injetar o contexto
    public class ClienteRepository : IClienteRepository
    {
        // Injetar o Context
        // Injecao de Dependencia
        private readonly EcommerceContext _context;

        // ctor <Cria o metodo abaixo>
        // Metodo construtor - Metodo que tem o mesmo nome da classe
        public ClienteRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, Cliente clienteNovo)
        {
            // Encontro o cliente que desejo atualizar
            Cliente clienteEncontrado = _context.Clientes.Find(id);

            // Tratamento de erro
            if (clienteEncontrado == null)
            {
                throw new ArgumentNullException("Cliente nao encontrado!!");
            }

            // Muda os dados um por um
            clienteEncontrado.NomeCompleto = clienteNovo.NomeCompleto;
            clienteEncontrado.Telefone = clienteNovo.Telefone;
            clienteEncontrado.Email = clienteNovo.Email;
            clienteEncontrado.Senha = clienteNovo.Senha;
            clienteEncontrado.Endereco = clienteNovo.Endereco;
            clienteEncontrado.DataCadatro = clienteNovo.DataCadatro;

            _context.SaveChanges(); // Sempre colocar o SaveChanges quando for mudar algo no Banco de Dados
        }

        /// <summary>
        /// Acessa o banco de dados, e encontra o Cliente com Email e Senha Fornecidos
        /// </summary>
        /// <returns>Um cliente ou nulo</returns>
        public Cliente? BuscarPorEmailSenha(string email, string senha)
        {
            // Encontrar o Cliente que possui o email e senha fornecidos
            var clienteEncontrado = _context.Clientes.FirstOrDefault(c => c.Email == email && c.Senha == senha);

            return clienteEncontrado;
        }

        public Cliente? BuscarPorId(int id)
        {
            // FirstorDefault - Traz o primeiro que encontrar ou null <nada> (melhor para filtrar)
            return _context.Clientes.FirstOrDefault(c => c.IdCliente == id); // Acessa a tabela, pega o primeiro que encontrar, me retorne aquele que tem o IdCliente igual ao id
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);

            _context.SaveChanges(); // Sempre colocar o SaveChanges quando for mudar algo no Banco de Dados
        }

        public void Deletar(int id)
        {
            // 1 - encontrar o que eu quero excluir
            Cliente clienteEncontrado = _context.Clientes.Find(id); // Find - Procura apenas pela chave primaria

            // Tratamento de erro
            if (clienteEncontrado == null)
            {
                throw new ArgumentNullException ("Cliente nao encontrado!!");
            }

            // 2 - Caso eu enconte o cliente, removo ele
            _context.Clientes.Remove(clienteEncontrado);

            // 3 - Salvo as alteracoes
            _context.SaveChanges();
        }

        public List<Cliente> ListarTodos()
        {
            // ToList() - Lista varios
            return _context.Clientes.ToList();
        }
    }
}

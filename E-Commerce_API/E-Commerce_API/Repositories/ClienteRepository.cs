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
        public void Atualizar(int id, Cliente cliente)
        {
            // Encontro o cliente que desejo
            Cliente clienteEncontrado = _context.Clientes.Find(id);

            // Tratamento de erro
            if (clienteEncontrado == null)
            {
                throw new Exception();
            }

            // Muda os dados um por um
            clienteEncontrado.NomeCompleto = cliente.NomeCompleto;
            clienteEncontrado.Telefone = cliente.Telefone;
            clienteEncontrado.Email = cliente.Email;
            clienteEncontrado.Endereco = cliente.Endereco;
            clienteEncontrado.DataCadatro = cliente.DataCadatro;

            _context.SaveChanges(); // Sempre colocar o SaveChanges quando for mudar algo no Banco de Dados
        }

        public Cliente BuscarPorEmailSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarPorId(int id)
        {
            // FirstorDefault - Traz o primeiro que encontrar ou null <nada> (melhor para filtrar)
            return _context.Clientes.FirstOrDefault(p => p.IdCliente == id); // Acessa a tabela, pega o primeiro que encontrar, me retorne aquele que tem o IdCliente igual ao id
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
                throw new Exception();
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

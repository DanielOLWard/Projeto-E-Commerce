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
            throw new NotImplementedException();
        }

        public Cliente BuscarPorEmailSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);

            _context.SaveChanges(); // Sempre colocar o SaveChanges quando for mudar algo no Banco de Dados
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ListarTodos()
        {
            return _context.Clientes.ToList();
        }
    }
}

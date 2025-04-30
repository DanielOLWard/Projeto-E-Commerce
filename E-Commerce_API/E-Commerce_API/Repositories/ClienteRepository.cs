using System.Numerics;
using E_Commerce_API.Context;
using E_Commerce_API.DTO;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using E_Commerce_API.Services;
using E_Commerce_API.ViewModels;

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

        // ctor <Atalho para criar o metodo abaixo>
        // Metodo construtor - Metodo que tem o mesmo nome da classe
        public ClienteRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, CadastrarClienteDTO clienteNovo)
        {
            // Encontro o cliente que desejo atualizar
            Cliente clienteEncontrado = _context.Clientes.Find(id);

            var senhaService = new SenhaService();
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

            clienteEncontrado.Senha = senhaService.HashPassword(clienteEncontrado);

            _context.SaveChanges(); // Sempre colocar o SaveChanges quando for mudar algo no Banco de Dados
        }

        // Busca o Cliente por email e senha (Login)
        public Cliente BuscarPorEmailSenha(string email, string senha)
        {
            // Encontrar o Cliente que possui o email fornecido
            var clienteEncontrado = _context.Clientes.FirstOrDefault(c => c.Email == email);

            // Caso nao encontre retorno null
            if (clienteEncontrado == null) {return null;}

            var passwordService = new SenhaService();

            // Verificar se a senha dada pelo usuario gera o mesmo hash
            var resultado = passwordService.VerificarSenha(clienteEncontrado, senha);

            if (resultado== true) {return clienteEncontrado;}

            return null;
        }

        public ListarClienteViewModel BuscarPorId(int id)
        {
            // FirstorDefault - Traz o primeiro que encontrar ou null <nada> (melhor para filtrar)
            return _context.Clientes
                .Select(c => new ListarClienteViewModel
                {
                    IdCliente = c.IdCliente,
                    NomeCompleto = c.NomeCompleto,
                    Email = c.Email,
                    Telefone = c.Telefone,
                    Endereco = c.Endereco
                })
                .FirstOrDefault(c => c.IdCliente == id); // Acessa a tabela, pega o primeiro que encontrar, me retorne aquele que tem o IdCliente igual ao id
        }

        public void Cadastrar(CadastrarClienteDTO dto)
        {
            var senhaService = new SenhaService();

            Cliente clienteCdastrado = new Cliente
            {
                NomeCompleto = dto.NomeCompleto,
                Email = dto.Email,
                Senha = dto.Senha,
                Telefone = dto.Telefone,
                Endereco = dto.Endereco,
                DataCadatro = dto.DataCadatro
            };

            clienteCdastrado.Senha = senhaService.HashPassword(clienteCdastrado);

            _context.Clientes.Add(clienteCdastrado);

            _context.SaveChanges(); // Sempre colocar o SaveChanges quando for mudar algo no Banco de Dados
        }

        public void Deletar(int id)
        {
            // 1 - encontrar o que eu quero excluir
            Cliente clienteEncontrado = _context.Clientes.Find(id); // Find - Procura apenas pela chave primaria

            // Tratamento de erro
            if (clienteEncontrado == null)
            {
                throw new ArgumentNullException("Cliente nao encontrado!!");
            }

            // 2 - Caso eu enconte o cliente, removo ele
            _context.Clientes.Remove(clienteEncontrado);

            // 3 - Salvo as alteracoes
            _context.SaveChanges();
        }

        public List<ListarClienteViewModel> ListarTodos()
        {
            // ToList() - Lista varios
            return _context.Clientes
                .Select(c => new ListarClienteViewModel  // Select - Seleciona apenas os dados que eu quero ou preciso
                {
                    IdCliente = c.IdCliente,
                    NomeCompleto = c.NomeCompleto,
                    Email = c.Email,
                    Telefone = c.Telefone,
                    Endereco = c.Endereco
                })
                .ToList();
        }

        public List<ListarClienteViewModel> BuscarPorNome(string nome)
        {
            // Where - Traz todos que atendem uma condicao
            // O Where tem uma construcao bem similar ao FirstOrDefault
            var listaCliente = _context.Clientes
                .Select(c => new ListarClienteViewModel // Tras o Cliente com o nome completo exato
                {
                    IdCliente = c.IdCliente,
                    NomeCompleto = c.NomeCompleto,
                    Email = c.Email,
                    Telefone = c.Telefone,
                    Endereco = c.Endereco
                })
                .Where(c => c.NomeCompleto == nome)
                .ToList(); // Sempre usar o ToList quando trazer mais de uma informacao

            return listaCliente;
        }

        public List<ListarClienteViewModel> OrdenarAlfabeticamente(string nome)
        {
            // OrderBy - Ordena em ordem alfabetica
            // O OrderBy tem uma construcao bem similar ao FirstOrDefault
            var ordernarCliente = _context.Clientes
                .Select(c => new ListarClienteViewModel // Seleciona apenas os dados do Cliente que constam na ViewModel
                {
                    IdCliente = c.IdCliente,
                    NomeCompleto = c.NomeCompleto,
                    Email = c.Email,
                    Telefone = c.Telefone,
                    Endereco = c.Endereco
                })
                .OrderBy(c => c.NomeCompleto) // OrderBy - ordena por ordem crescente, OrderByDescending - ordena por ordem decrescente
                .ToList(); // Sempre usar o ToList quando trazer mais de uma informacao

            return ordernarCliente;
        }

        public List<ListarClienteViewModel> BuscarNomeParcial(string nomeParcial)
        {
            throw new NotImplementedException();
            /*
                var buscarCliente = _context.Clientes
                    .Select(c => new ListarClienteViewModel // Seleciona apenas os dados do Cliente que constam na ViewModel
                    {
                        IdCliente = c.IdCliente,
                        NomeCompleto = c.NomeCompleto,
                        Email = c.Email,
                        Telefone = c.Telefone,
                        Endereco = c.Endereco
                    })
                    .Contains(c => c.NomeCompleto == nomeParcial)
                    .ToList();
            }
            */
        }
    }
}
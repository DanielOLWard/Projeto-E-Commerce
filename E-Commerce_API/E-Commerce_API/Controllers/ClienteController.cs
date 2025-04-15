using E_Commerce_API.Context;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using E_Commerce_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _clienteRepository;

        // Injecao de dependencia
        // Ao invez de EU instanciar a classe, Eu aviso que DEPENDO dela, e a responsabilidade de criar vai para a classe que chama
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // Get - Listar uma ou mais informacoes para o front 
        [HttpGet]
        public IActionResult ListarClientes()
        {
            // 200 - ok <Deu certo>
            return Ok(_clienteRepository.ListarTodos());
        }

        // Cadastrar Cliente
        // Post - Cliente uma ou mais informacoes para o front 
        [HttpPost]
        public IActionResult CadastrarCliente(Cliente cliente)
        {
            // 1 - Coloco o Cliente no banco de dados
            _clienteRepository.Cadastrar(cliente);

            // 2 - Retorne um resultado
            // 201 - Created <Criado>
            return Created();
        }
    }
}

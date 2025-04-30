using E_Commerce_API.Context;
using E_Commerce_API.DTO;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using E_Commerce_API.Repositories;
using E_Commerce_API.Services;
using E_Commerce_API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _clienteRepository;

        // Instanciar o SenhaService
        private SenhaService senhaService = new SenhaService();

        // Injecao de dependencia
        // Ao invez de EU instanciar a classe, Eu aviso que DEPENDO dela, e a responsabilidade de criar vai para a classe que chama
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // Get - Listar uma ou mais informacoes para o front 
        [HttpGet]
        [Authorize] // Autoriza apenas pessoas autorizadas
        public IActionResult ListarClientes()
        {
            // 200 - ok <Deu certo>
            return Ok(_clienteRepository.ListarTodos());
        }

        // Cadastrar Cliente
        // Post - Cliente uma ou mais informacoes para o front 
        [HttpPost]
        public IActionResult CadastrarCliente(CadastrarClienteDTO cliente)
        {
            // 1 - Coloco o Cliente no banco de dados
            _clienteRepository.Cadastrar(cliente);

            // 2 - Retorne um resultado
            // 201 - Created <Criado>
            return Created();
        }
        // Buscar Cliente por ID
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            ListarClienteViewModel cliente = _clienteRepository.BuscarPorId(id);

            if (cliente == null)
            {
                //erro404 - nao encontrado
                return NotFound(); // Retorna 404 se não encontrar o cliente
            }

            return Ok(cliente); // Retorna 200 com os dados do cliente
        }
        // Atualizar o Cliente por ID
        [HttpPut("{id}")]
        public IActionResult AtualizarCliente(int id, CadastrarClienteDTO clie)
        {
            // Usando o try/catch pois o repositoy lancou um erro (sempre usar o try/catch para tratar com erros
            try
            {
                _clienteRepository.Atualizar(id, clie);

                return Ok(clie);
            }
            catch (Exception ex)
            {
                return NotFound("Cliente nao encontrado!");
            }
        }
        // Deleta Cliente por ID
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            // Usando o try/catch pois o repositoy lancou um erro (sempre usar o try/catch para tratar com erros
            try
            {
                _clienteRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound("Cliente nao encontrado!");
            }
        }

        // Buscar Cliente por Email e Senha
        // /api/login
        [HttpPost("login")]
        public IActionResult Login(LoginDTO login)
        {
            var cliente = _clienteRepository.BuscarPorEmailSenha(login.Email, login.Senha);
            if (cliente == null)
            { 
                return Unauthorized("Email ou Senha invalido!");
            }
            var tokenService = new TokenService();

            var token = tokenService.GerarToken(cliente.Email);

            return Ok(token);
        }

        // Buscar Cliente por Nome
        // /api/cliente/buscar/nome
        // O navegador nao entende quando tem 2 endpoints "enguais" entao e necessario criar um novo endpoint
        [HttpGet("buscar/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            return Ok(_clienteRepository.BuscarPorNome(nome));
        }

        // Ordernar por Ordem Alfabetica
        [HttpGet("/ordernar/{nome}")]
        public IActionResult OrdenarAlfabeticamente(string nome)
        {
            return Ok(_clienteRepository.OrdenarAlfabeticamente(nome));
        }
    }
}
using E_Commerce_API.Context;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using E_Commerce_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private IPagamentoRepository _pagamentoRepository;

        // Injecao de dependencia
        // Ao invez de EU instanciar a classe, Eu aviso que DEPENDO dela, e a responsabilidade de criar vai para a classe que chama
        public PagamentoController(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        // Get - Listar uma ou mais informacoes para o front  
        [HttpGet]
        public IActionResult ListarPagamentos()
        {
            // 200 - ok <Deu certo>
            return Ok(_pagamentoRepository.ListarTodos());
        }

        // Cadastrar Pagamento
        // Post - Cadastrar uma ou mais informacoes para o front 
        [HttpPost]
        public IActionResult CadastrarPagamento(Pagamento pagamento)
        {
            // 1 - Coloco o Pagamento no banco de dados
            _pagamentoRepository.Cadastrar(pagamento);

            // 2 - Retorne um resultado
            // 201 - Created <Criado>
            return Created();
        }
    }
}

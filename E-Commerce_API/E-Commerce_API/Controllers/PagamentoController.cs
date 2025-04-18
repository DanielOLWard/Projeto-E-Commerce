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
        // Buscar Pagamento por ID
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            Pagamento pagamento = _pagamentoRepository.BuscarPorId(id);
            if (pagamento == null)
            {
                //erro404 - nao encontrado
                return NotFound(); // Retorna 404 se não encontrar o pagamento
            }

            return Ok(pagamento); // Retorna 200 com os dados do produto
        }
        // Atualizar o Pagamento por ID
        [HttpPut("{id}")]
        public IActionResult AtualizarPagamento(int id, Pagamento pag)
        {
            // Usando o try/catch pois o repositoy lancou um erro (sempre usar o try/catch para tratar com erros
            try
            {
                _pagamentoRepository.Atualizar(id, pag);

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Pagamento nao econtrado!");
            }
        }
        // Deleta Pagamento por ID
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            // Usando o try/catch pois o repositoy lancou um erro (sempre usar o try/catch para tratar com erros
            try
            {
                _pagamentoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound("Pagamento nao encontrado!");
            }
        }
    }
}

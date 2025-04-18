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
    public class ProdutoController : ControllerBase
    {
        private IProdutoRepository _produtoRepository;

        // Metodo Construtor
        // Injecao de dependencia
        // Ao invez de EU instanciar a classe, Eu aviso que DEPENDO dela, e a responsabilidade de criar vai para a classe que chama
        public ProdutoController (IProdutoRepository produtoRepository)
        {
        _produtoRepository = produtoRepository;
        }

        // Get - Listar uma ou mais informacoes para o front 
        [HttpGet]
        public IActionResult ListarProdutos()
        {
            // 200 - ok <Deu certo>
            return Ok(_produtoRepository.ListarTodos());
        }

        // Cadastrar Produto
        // Post - Cadastrar uma ou mais informacoes para o front 
        [HttpPost]
        public IActionResult CadastrarProduto(Produto produto)
        {
            // 1 - Coloco o Produto no banco de dados
            _produtoRepository.Cadastrar(produto);

            // 2 - Retorne um resultado
            // 201 - Created <Criado>
            return Created();
        }
        // Buscar Produto por ID
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            Produto produto = _produtoRepository.BuscarPorId(id);

            if (produto == null)
            {
                //erro404 - nao encontrado
                return NotFound(); // Retorna 404 se não encontrar o produto
            }

            return Ok(produto); // Retorna 200 com os dados do produto
        }
        // Atualizar o Produto por ID
        [HttpPut("{id}")]
        public IActionResult AtualizarProduto(int id, Produto prod)
        {
            // Usando o try/catch pois o repositoy lancou um erro (sempre usar o try/catch para tratar com erros
            try
            {
                _produtoRepository.Atualizar(id, prod);

                return Ok(prod);
            }
            catch (Exception ex)
            {
                return NotFound("Produto nao encontrado!");
            }
        }
        // Deleta Produto por ID
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            // Usando o try/catch pois o repositoy lancou um erro (sempre usar o try/catch para tratar com erros
            try
            {
                _produtoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound("Produto nao encontrado!");
            }
        }
    }
}

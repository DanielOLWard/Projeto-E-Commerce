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
        public ProdutoController (ProdutoRepository produtoRepository)
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
    }
}

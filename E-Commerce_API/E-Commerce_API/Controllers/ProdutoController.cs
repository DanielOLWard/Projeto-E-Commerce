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
        private readonly EcommerceContext _context;
        private IProdutoRepository _produtoRepository;

        public ProdutoController(EcommerceContext context)
        {
            _context = context;
            _produtoRepository = new ProdutoRepository(_context);
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

            // 2 - Salvo a alteracao
            _context.SaveChanges(); // Sempre colocar o SaveChanges quando for mudar algo no Banco de Dados

            // 3 - Retorne um resultado
            // 201 - Created <Criado>
            return Created();
        }
    }
}

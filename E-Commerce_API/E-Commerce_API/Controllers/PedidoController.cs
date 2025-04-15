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
    public class PedidoController : ControllerBase
    {
        private IPedidoRepository _pedidoRepository;

        // Injecao de dependencia
        // Ao invez de EU instanciar a classe, Eu aviso que DEPENDO dela, e a responsabilidade de criar vai para a classe que chama
        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        // Get - Listar uma ou mais informacoes para o front
        [HttpGet]
        public IActionResult ListarPedidos()
        {
            // 200 - ok <Deu certo>
            return Ok(_pedidoRepository.ListarTodos());
        }

        // Cadastrar Pedido
        // Post - Cadastrar uma ou mais informacoes para o front 
        [HttpPost]
        public IActionResult CadastrarPedido(Pedido pedido)
        {
            // 1 - Coloco o Pedido no banco de dados
            _pedidoRepository.Cadastrar(pedido);

            // 2 - Retorne um resultado
            // 201 - Created <Criado>
            return Created();
        }
    }
}

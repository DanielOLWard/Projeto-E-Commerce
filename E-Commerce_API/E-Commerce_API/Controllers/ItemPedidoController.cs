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
    public class ItemPedidoController : ControllerBase
    {
        private IItemPedidoRepository _itemPedidoRepository;

        // Injecao de dependencia
        // Ao invez de EU instanciar a classe, Eu aviso que DEPENDO dela, e a responsabilidade de criar vai para a classe que chama
        public ItemPedidoController(IItemPedidoRepository itemPedidoRepository)
        {
            _itemPedidoRepository = itemPedidoRepository;
        }

        // Get - Listar uma ou mais informacoes para o front 
        [HttpGet]
        public IActionResult ListarItemPedidos()
        {
            // 200 - ok <Deu certo>
            return Ok(_itemPedidoRepository.ListarTodos());
        }

        // Cadastrar ItemPedido
        // Post - Cadastrar uma ou mais informacoes para o front 
        [HttpPost]
        public IActionResult CadastrarItemPedido(ItemPedido itemPedido)
        {
            // 1 - Coloco o ItemPedido no banco de dados
            _itemPedidoRepository.Cadastrar(itemPedido);

            // 2 - Retorne um resultado
            // 201 - Created <Criado>
            return Created();
        }
    }
}

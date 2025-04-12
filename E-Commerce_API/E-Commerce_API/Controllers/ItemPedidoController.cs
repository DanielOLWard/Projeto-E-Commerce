using E_Commerce_API.Context;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private IItemPedidoRepository _itemPedidoRepository;

        public ItemPedidoController(EcommerceContext context)
        {
            _context = context;
            _itemPedidoRepository = new ItemPedidoRepository(_context);
        }

        // 1 - Definir o verbo <GET> 
        [HttpGet]
        public IActionResult ListarItemPedidos()
        {
            return Ok(_itemPedidoRepository.ListarTodos());
        }
    }
}

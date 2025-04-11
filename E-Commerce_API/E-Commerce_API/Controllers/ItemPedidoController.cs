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
        private IItemPedidoRepository _itemPagamentoRepository;

        public ItemPedidoController(EcommerceContext context)
        {
            _context = context;
            _itemPagamentoRepository = new ItemPedidoRepository(_context);
        }

        // GET 
        [HttpGet]
        public IActionResult ListarItemPedidos()
        {
            return Ok(_itemPagamentoRepository.ListarTodos());
        }
    }
}

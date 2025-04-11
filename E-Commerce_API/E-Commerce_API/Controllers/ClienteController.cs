using E_Commerce_API.Context;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private IClienteRepository _clineteRepository;

        public ClienteController(EcommerceContext context)
        {
            _context = context;
            _clineteRepository = new ClienteRepository(_context);
        }

        // GET 
        [HttpGet]
        public IActionResult ListarClientes()
        {
            return Ok(_clineteRepository.ListarTodos());
        }
    }
}

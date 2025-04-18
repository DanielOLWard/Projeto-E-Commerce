﻿using E_Commerce_API.Context;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using E_Commerce_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _clienteRepository;

        // Injecao de dependencia
        // Ao invez de EU instanciar a classe, Eu aviso que DEPENDO dela, e a responsabilidade de criar vai para a classe que chama
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // Get - Listar uma ou mais informacoes para o front 
        [HttpGet]
        public IActionResult ListarClientes()
        {
            // 200 - ok <Deu certo>
            return Ok(_clienteRepository.ListarTodos());
        }

        // Cadastrar Cliente
        // Post - Cliente uma ou mais informacoes para o front 
        [HttpPost]
        public IActionResult CadastrarCliente(Cliente cliente)
        {
            // 1 - Coloco o Cliente no banco de dados
            _clienteRepository.Cadastrar(cliente);

            // 2 - Retorne um resultado
            // 201 - Created <Criado>
            return Created();
        }
        // Buscar Produto por ID
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            Cliente cliente = _clienteRepository.BuscarPorId(id);

            if (cliente == null)
            {
                //erro404 - nao encontrado
                return NotFound(); // Retorna 404 se não encontrar o cliente
            }


            return Ok(cliente); // Retorna 200 com os dados do cliente
        }
        // Atualizar o Cliente por ID
        [HttpPut("{id}")]
        public IActionResult AtualizarCliente(int id, Cliente clie)
        {
            // Usando o try/catch pois o repositoy lancou um erro (sempre usar o try/catch para tratar com erros
            try
            {
                _clienteRepository.Atualizar(id, clie);

                return Ok(clie);
            }
            catch (Exception ex)
            {
                return NotFound("Cliente nao encontrado!");
            }
        }
        // Deleta Cliente por ID
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            // Usando o try/catch pois o repositoy lancou um erro (sempre usar o try/catch para tratar com erros
            try
            {
                _clienteRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound("Cliente nao encontrado!");
            }
        }
    }
}

﻿using E_Commerce_API.Context;
using E_Commerce_API.DTO;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using E_Commerce_API.Repositories;
using E_Commerce_API.ViewModels;
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
        public IActionResult CadastrarPedido(CadastrarPedidoDTO pedido)
        {
            // 1 - Coloco o Pedido no banco de dados
            _pedidoRepository.Cadastrar(pedido);

            // 2 - Retorne um resultado
            // 201 - Created <Criado>
            return Created();
        }

        // Atualizar Pedido
        [HttpPut("{id}")]
        public IActionResult AtualizarPedido(int id, CadastrarPedidoDTO pedidoDTO)
        {
            try
            {
                _pedidoRepository.Atualizar(id, pedidoDTO);
                return Ok(pedidoDTO);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound("Pedido nao encontrado!");
            }
        }
        // Buscar por Id
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            ListarPedidoViewModel pedido = _pedidoRepository.BuscarPorId(id);

            if (pedido == null)
            {
                //erro404 - nao encontrado
                return NotFound(); // Retorna 404 se não encontrar o cliente
            }

            return Ok(pedido); // Retorna 200 com os dados do cliente
        }

        // Deleta Peiddo por ID
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            // Usando o try/catch pois o repositoy lancou um erro (sempre usar o try/catch para tratar com erros
            try
            {
                _pedidoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound("Produto nao encontrado!");
            }
        }
    }
}

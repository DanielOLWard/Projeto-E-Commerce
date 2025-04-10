﻿using E_Commerce_API.Models;

namespace E_Commerce_API.Interfaces
{
    public interface IIitemPedidoRepository
    {
        List<ItemPedido> ListarTodos();

        ItemPedido BuscarPorId(int id);

        void Cadastrar(ItemPedido itemPedido);

        void Atualizar(int id, ItemPedido itemPeido);

        void Deletar(int id);
    }
}

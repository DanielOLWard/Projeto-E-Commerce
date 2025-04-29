using E_Commerce_API.Models;
using System.Text.Json.Serialization;

namespace E_Commerce_API.ViewModels
{
    public class ListarPedidoViewModel
    {
        public int IdPedido { get; set; }

        public DateOnly DataPedido { get; set; }

        public string StatusPedido { get; set; } = null!;

        public decimal? ValorTotal { get; set; }

        public int IdCliente { get; set; }

        public virtual ICollection<ItemPedido> ItemPedidos { get; set; } = new List<ItemPedido>();

    }
}

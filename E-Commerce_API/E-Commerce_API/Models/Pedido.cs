using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace E_Commerce_API.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public DateOnly DataPedido { get; set; }

    public string StatusPedido { get; set; } = null!;

    public decimal? ValorTotal { get; set; }

    public int IdCliente { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<ItemPedido> ItemPedidos { get; set; } = new List<ItemPedido>();

    // Cortando a navegacao para nao gerar um ciclo infinito
    // JsonIgnore para ignorar o Pagamentos
    [JsonIgnore]    // Tambem da pra apagar
    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}

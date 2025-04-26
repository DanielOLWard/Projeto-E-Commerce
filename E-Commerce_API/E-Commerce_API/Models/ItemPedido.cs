using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace E_Commerce_API.Models;

public partial class ItemPedido
{
    public int IdItemPedido { get; set; }

    public int Quantidade { get; set; }

    public int IdPedido { get; set; }

    public int IdProduto { get; set; }

    [JsonIgnore]
    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Produto IdProdutoNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace E_Commerce_API.Models;

public partial class Pagamento
{
    public int IdPagamento { get; set; }

    public string FormaPagamento { get; set; } = null!;

    public string StatusPagamento { get; set; } = null!;

    public DateTime DataPagamento { get; set; }

    public int? IdPedido { get; set; }

    public virtual Pedido? IdPedidoNavigation { get; set; }
}

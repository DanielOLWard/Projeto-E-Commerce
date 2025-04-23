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

    // Esta com o nome IdPedidoNavigation pois nao foi criado no padrao do Entity
    // Padrao Entity <nome da Tabela>Id
    // Como esta na tebela Id <nome da tabela>
    // Para alterar o nome precisa alterar ele no contexto tbm
    // Nao alterei para o comentario nao ficar "solto"
    public virtual Pedido? IdPedidoNavigation { get; set; }
}

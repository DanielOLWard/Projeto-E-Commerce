namespace E_Commerce_API.DTO
{
    // Recebo os dados do Pedido
    // E recebo os Produtos comprados
    public class CadastrarPedidoDTO
    {
        public DateOnly DataPedido { get; set; }

        public string StatusPedido { get; set; } = null!;

        public decimal? ValorTotal { get; set; }

        public int IdCliente { get; set; }

        // Produtos comprados
        public List<int> Produtos { get; set; }
    }
}

namespace E_Commerce_API.DTO
{
    public class CadastrarPagamentosDTO
    {
        public int IdPagamento { get; set; }

        public string FormaPagamento { get; set; } = null!;

        public string StatusPagamento { get; set; } = null!;

        public DateTime DataPagamento { get; set; }
    }
}

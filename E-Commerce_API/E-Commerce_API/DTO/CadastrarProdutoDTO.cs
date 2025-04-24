namespace E_Commerce_API.DTO
{
    public class CadastrarProdutoDTO
    {
        public int IdProduto { get; set; }

        public string NomeProduto { get; set; } = null!;

        public string? Descricao { get; set; }

        public decimal Preco { get; set; }

        public int QtdEstoque { get; set; }

        public string Categoria { get; set; } = null!;

        public string? Imagem { get; set; }
    }
}

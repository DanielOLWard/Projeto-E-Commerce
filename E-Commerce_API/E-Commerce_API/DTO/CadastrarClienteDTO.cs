namespace E_Commerce_API.DTO
{
    public class CadastrarClienteDTO
    {
        public string NomeCompleto { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Senha { get; set; } = null!;

        public string? Telefone { get; set; }

        public string? Endereco { get; set; }

        public DateOnly? DataCadatro { get; set; }
    }
}

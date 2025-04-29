using E_Commerce_API.Models;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce_API.Services
{
    public class SenhaService
    {
        // PasswordHasher - PBKDF2
        //private readonly PasswordHasher<Cliente> _Hasher = new(); / Maneira abreviada da de baixo
        private readonly PasswordHasher<Cliente> _Hasher = new PasswordHasher<Cliente>();

        // 1 - Gerar um Hash
        public string HashPassword(Cliente cliente) 
        {
            return _Hasher.HashPassword(cliente, cliente.Senha);
        }

        // 2 - Verificar o Hash
        public bool VerificarSenha(Cliente cliente, string senhaInformada)
        {
            var resultado = _Hasher.VerifyHashedPassword(cliente, cliente.Senha, senhaInformada);
            return resultado == PasswordVerificationResult.Success;
        }
    }
}

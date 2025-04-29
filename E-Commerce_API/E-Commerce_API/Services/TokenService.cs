using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace E_Commerce_API.Services
{
    public class TokenService
    {
        public string GerarToken(string email)
        {
            // Claim - Informacoes do usuario que quero guardar
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email)
            };
            // Criar uma chave de seguranca e criptografar ela
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-secreta-senai"));
        }
    }
}

/* Passo a passo da API

// 1 - Instalar os pacotes do Entity Framework <Microsoft.EntityFrameworkCore.Tools> <Microsoft.EntityFrameworkCore.Tools> <Microsoft.EntityFrameworkCore.Tools>

// 2 - Realizar o Scaffold, colocar esse codigo no terminal da solucao:
// dotnet ef dbcontext scaffold "Data Source=NOTE04-S28\SQLEXPRESS;Initial Catalog=ECommerce;User Id=sa;Password=Senai@134;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --context-dir Context --output-dir Models

// 3 - Criar as pastas <Interfaces> <Repositories> <Controllers>

// 4 - Criar a interface, de cada model

// 5 - Criar a repository, de cada model

// 6 - Criar o Controller, de cada model

 7 - Configurar a Program.cs */

/* Instalando o Swagger

// 1 - Instalar os pacotes do Swaggwers <Swashbuckle.AspNetCore.SwaggerGen> <Swashbuckle.AspNetCore.SwaggerUI>

// 2 - Colocar os comandos do Swaggers na Program <builder.Services.AddSwaggerGen();> <app.UseSwagger();> <app.UseSwaggerUI();>

// Se ultiliza o Swaggers no http usando o sSwagger na URL */

using System.Text;
using E_Commerce_API.Context;
using E_Commerce_API.Controllers;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Repositories;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args); // Nao mexer e sempre deixar ela no comeco (com excessao dos "using")

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

// O .NET vai criar os objetos (Injecao de Dependencia)

// AddTransient - o C# cria uma instancia nova roda vez que um metodo e chamado

// AddScoped - O C# cria uma instancia nova toda vez que criar um Controller

// AddSingleton 

// AddDbContext - Mesma coisa do Scoped,mas especifico para o Contexto

builder.Services.AddDbContext<EcommerceContext>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();

// Valida os tokens
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // o C# vai verificar se os dados batem
            ValidateAudience = true, // o C# vai verificar se os dados batem
            ValidateLifetime = true, // o C# vai verificar se os dados batem
            ValidateIssuerSigningKey = true, // o C# vai verificar se os dados batem
            ValidIssuer = "ecommerce", // Tem que ser igual as Issuer e Audience do TokenService
            ValidAudience = "ecommerce",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-ultra-mega-secreta-de-seguranca-do-senai")) // Usa a mesma linha que cria a chave no TokenService
        };
    });

// Cria as autorizacoes do usuarios, limitando as EndPoins dos usuarios
builder.Services.AddAuthorization();

var app = builder.Build(); // O C# controi o "site" NAO MEXER, Colocar os codigos entre ele e o "var builder"

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.UseAuthentication(); // usa autenticacao

app.UseAuthorization(); // Usa a autorizacao

app.Run(); // sempre sera a ultima linha de codigo, pois codigos depois dela nao ira funcionar
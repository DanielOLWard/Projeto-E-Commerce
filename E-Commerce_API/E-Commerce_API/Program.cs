// Passo a passo da API

// 1 - Instalar os pacotes do Entity Framework <Microsoft.EntityFrameworkCore.Tools> <Microsoft.EntityFrameworkCore.Tools> <Microsoft.EntityFrameworkCore.Tools>

// 2 - Realizar o Scaffold, colocar esses codigos no terminal da solucao: dotnet tool install --global dotnet-ef
// dotnet ef dbcontext scaffold "Data Source=.\\SQLEXPRESS;Initial Catalog=ECommerce;User Id=sa;Password=Senai@134;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --context-dir Context --output-dir Models

// 3 - Criar as pastas <Interfaces> <Repositories> <Controllers>

// 4 - Criar a interface, de cada model

// 5 - Criar a repository, de cada model

// 6 - Criar o Controller, de cada model

// 7 - Configurar a Program.cs 
///

// Instalando o Swagger

// 1 - Instalar os pacotes do Swaggwers <Swashbuckle.AspNetCore.SwaggerGen> <Swashbuckle.AspNetCore.SwaggerUI>

// 2 - Colocar os comandos do Swaggers na Program <builder.Services.AddSwaggerGen();> <app.UseSwagger();> <app.UseSwaggerUI();>

// Se ultiliza o Swaggers no http usando o sSwagger na URL
///


using E_Commerce_API.Context;
using E_Commerce_API.Controllers;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

// O .NET vai criar os objetos (Injecao de Dependencia)

// AddTransient - o C# cria uma instancia nova roda vez que um metodo e chamado

// AddScoped - O C# cria uma instancia nova toda vez que criar um Controller

// AddSingleton 

builder.Services.AddScoped<EcommerceContext, EcommerceContext>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.Run();

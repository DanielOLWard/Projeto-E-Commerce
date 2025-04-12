// Passo a passo da API

// 1 - Instalar os pacotes do Entity Framework <Core.Design> <Core.SqlServer> <Core.Tools>

// 2 - Realizar o Scaffold, colocar esses codigos no terminal da solucao: dotnet tool install --global dotnet-ef
// dotnet ef dbcontext scaffold "Data Source=NOTE-VINICIO\SQLEXPRESS;Initial Catalog=ECommerce;User Id=sa;Password=Senai@134;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --context-dir Context --output-dir Models

// 3 - Criar as pastas <Interfaces> <Repositories> <Controllers>

// 4 - Criar a interface, de cada model

// 5 - Criar a repository, de cada model

// 6 - Criar o Controller, de cada model

// 7 - Configurar a Program.cs

using E_Commerce_API.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddTransient<EcommerceContext, EcommerceContext>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.Run();

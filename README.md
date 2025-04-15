# Criando uma API - Passo a Passo
## 1- Configurar o Entity

### 1- Instalar os pacotes do Entity Framework [Microsoft.EntityFrameworkCore.Tools] [Microsoft.EntityFrameworkCore.Tools] [Microsoft.EntityFrameworkCore.Tools]

### 2- Realizar o Scaffold, colocar esses codigos no terminal da solucao
dotnet tool install --global dotnet-ef

dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Chinook" Microsoft.EntityFrameworkCore.SqlServer 

[Editar as partes necessarias]

## 2 - Criando a(s) Interfaces

### Criar os CRUD
ListarTodos

BuscarPorId 

Cadastrar 

Atualizar 

Deletar 

## 3 - Criar a(s) Classe Repository

### 1- Herdar a Interface

### 2- Implementar a Interface 

### 4- Criar a variavel Contexto

### 5- Criar o Metodo Contrutor

### 6- Implementar os Metodos

## 4- Confirgurar a Injecao de Dependencia [Program.cs]

### 1- Injetar a Instancia do Contexto [AddScoped]

### 2- Injetar a Instancia dos Repositories/Controller [AddTransient]

## 5- Criar o(s) Controllers

### 1- Injetar o Repository

### 2- Criar os Metodos do CRUD
ListarTodos

BuscarPorId 

Cadastrar 

Atualizar 

Deletar 

Fazer o httpGet - Listar as Informacoes para o Front

Fazer o httpPost - Cadastrar Informacoes para o Front

## 6(opcional)- Configurar o Swagger

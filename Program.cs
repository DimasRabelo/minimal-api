using MinimalApi.Infraestrutura.Db;
using MinimalApi.DTOS;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministradorServico, AdministradorServico>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configuração do DbContext
builder.Services.AddDbContext<DbContexto>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("mysql");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

// Rota de login de exemplo
app.MapPost("/login", ([FromBody] LoginDTO loginDTO, IAdministradorServico administradorServico) =>
{
    if (administradorServico.Login(loginDTO) != null)
    {
        return Results.Ok("Login realizado com sucesso!");
    }
    else
    {
        return Results.Unauthorized();
    }
});


app.UseSwagger();
app.UseSwaggerUI();

app.Run();



using Duende.IdentityServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProdutoCRUD.Identity;
using ProdutoCRUD.Infraestructure.Data;
using ProdutoCRUD.Infraestructure.Repositories;
using produtoCRUD.Application.Handlers;
using ProdutoCRUD.Domain.Interfaces;

//

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configuração do EF e do SQLS
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração do IdentityServer
builder.Services.AddIdentityServer()
    .AddInMemoryApiScopes(IdentityServerConfig.ApiScopes)
    .AddInMemoryApiResources(IdentityServerConfig.ApiResources)
    .AddInMemoryClients(IdentityServerConfig.Clientes)
    .AddDeveloperSigningCredential(); // <- Certificado de testes

// Configuração do JWT Bearer
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "http://localhost:5001"; // URL do IdentityServer
        options.Audience = "produtoapi"; // Nome da API
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });

// Configuração do Repositório e Handlers
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ProdutoCommandHandler>();
builder.Services.AddScoped<ProdutoQueryHandler>();


builder.Services.AddControllers();
var app = builder.Build();

// Habilitar autenticação.
app.UseAuthentication();
app.UseAuthorization();

// Habilitar IdentityServer
app.UseIdentityServer();
app.MapControllers();
app.Run();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

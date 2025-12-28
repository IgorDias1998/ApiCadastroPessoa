using ApiCadastroPessoa.Application.Interfaces;
using ApiCadastroPessoa.Application.Services;
using ApiCadastroPessoa.Domain.Interfaces;
using ApiCadastroPessoa.Infrastructure.Data;
using ApiCadastroPessoa.Infrastructure.Repositories;
using ApiCadastroPessoa.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins("http://localhost:4200") // Angular dev
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var connectionString = builder.Configuration.GetConnectionString("MySql");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    )
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//CEP
builder.Services.AddHttpClient<ICepService, BuscarCepService>();
//Repository
builder.Services.AddScoped<ICadastroPessoaRepository, CadastroPessoaRepository>();
//Application
builder.Services.AddScoped<CadastroPessoaService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

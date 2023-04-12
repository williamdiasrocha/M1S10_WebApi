using System;
using Microsoft.EntityFrameworkCore;
using ProjetoWebApi.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = "Server=DESKTOP-D0KS0IT\\SQLEXPRESS;Database=Locacao;Trusted_Connection=True;TrustServerCertificate=True;";
builder.Services.AddDbContext<LocacaoContext>(o => o.UseSqlServer(connectionString));


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

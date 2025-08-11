using API.Data;
using API.Interfaces;
using API.Interfaces.Stock3s;
using API.Interfaces.Stocks;
using API.Repositories;
using API.Servcies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlite("Data Source=api.db")
);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IStockRepository, StockRepository>();

builder.Services.AddScoped<IStock2Service, Stock2Service>();
builder.Services.AddScoped<IStock2Repository, Stock2Repository>();

builder.Services.AddScoped<IStock3Service, Stock3Service>();
builder.Services.AddScoped<IStock3Repository, Stock3Repository>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

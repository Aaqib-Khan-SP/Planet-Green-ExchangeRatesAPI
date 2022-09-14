using ExchangeRatesAPI;
using ExchangeRatesAPI.Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc(options =>
{
    options.Filters.Add<ExceptionFilter>();
});
builder.Services.AddDbContext<ExchangeRatesDBContext>(options => options.UseInMemoryDatabase("exchange_rates"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using ExchangeRatesAPI;
using ExchangeRatesAPI.Filters;
using ExchangeRatesAPI.Infrastructure;
using ExchangeRatesAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc(options =>
{
    options.Filters.Add<ExceptionFilter>();
});
builder.Services.AddScoped<IExchangeRates,ExchangeRatesService>();
builder.Services.AddDbContext<ExchangeRatesDBContext>(options => options.UseInMemoryDatabase("exchange_rates"));
builder.Services.AddAutoMapper(options => options.AddProfile<MappingProfile>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

InitializeDatabase(app);

static void InitializeDatabase(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            SeedData.InitializeAsync(services);
        }
        catch (Exception ex)
        {

        }
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

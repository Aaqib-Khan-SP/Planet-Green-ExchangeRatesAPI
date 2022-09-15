using ExchangeRatesAPI.Models;

namespace ExchangeRatesAPI
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            await AddTestData(services.GetRequiredService<ExchangeRatesDBContext>());
        }
        public static async Task AddTestData(ExchangeRatesDBContext context)
        {
            if (context.ExchangeRates.Any())
            {
                return;
            }
            context.ExchangeRates.Add(new ExchangeRateEntity()
            {
                CurrencyCode = "USD",
                CurrencyName = "U.S. dollar",
                Date = DateTime.Today,
                Rate = 1
            });
            await context.SaveChangesAsync();
        }
    }
}

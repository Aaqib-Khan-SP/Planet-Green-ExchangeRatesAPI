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
                Date = DateTime.Today.ToString("d"),
                Rate = 12.3m,
                CurrencyCode = "USD",
            });
            context.ExchangeRates.Add(new ExchangeRateEntity()
            {
                Date = DateTime.Today.ToString("d"),
                Rate = 22.3m,
                CurrencyCode = "USD",
            });
            context.ExchangeRates.Add(new ExchangeRateEntity()
            {
                Date = DateTime.Today.ToString("d"),
                Rate = 109.3m,
                CurrencyCode = "INR",
            });
            await context.SaveChangesAsync();
        }
    }
}

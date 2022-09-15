using ExchangeRatesAPI.Models;

namespace ExchangeRatesAPI.Services
{
    public interface IExchangeRates
    {
        Task<ExchangeRate> GetExchangeRates(string currencyCode); 
    }
}

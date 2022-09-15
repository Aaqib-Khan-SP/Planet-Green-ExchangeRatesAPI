namespace ExchangeRatesAPI.Models
{
    public class ExchangeRates
    {
        public string CurrencyCode { get; set; }
        public List<ExchangeRate> Rates { get; set; }
    }
}

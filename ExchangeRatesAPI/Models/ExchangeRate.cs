namespace ExchangeRatesAPI.Models
{
    public class ExchangeRate : Resource
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public DayRate? Rates { get; set; }
    }
}

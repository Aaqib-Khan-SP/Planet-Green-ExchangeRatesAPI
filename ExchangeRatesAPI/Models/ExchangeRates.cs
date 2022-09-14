namespace ExchangeRatesAPI.Models
{
    public class ExchangeRates
    {
        public string CurrencyName { get; set; }
        public List<DayRate> Rates {get;set;}
    }
}

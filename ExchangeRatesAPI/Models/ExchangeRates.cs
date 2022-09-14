namespace ExchangeRatesAPI.Models
{
    public class ExchangeRates
    {
        public string CurrencyName { get; set; }
        public DateTime Date { get; set;}
        public decimal Rate { get; set; }
    }
}

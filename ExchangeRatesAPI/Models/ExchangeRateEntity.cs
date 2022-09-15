namespace ExchangeRatesAPI.Models
{
    public class ExchangeRateEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CurrencyCode { get; set;}
        public string CurrencyName { get; set; }
        public DateTime Date { get; set; }
        public decimal Rate { get; set; }
    }
}

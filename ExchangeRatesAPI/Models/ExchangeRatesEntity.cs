namespace ExchangeRatesAPI.Models
{
    public class ExchangeRatesEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CurrencyName { get; set; }
        public DateTime Date { get; set; }
        public decimal Rate { get; set; }
    }
}

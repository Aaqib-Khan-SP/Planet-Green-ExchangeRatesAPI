namespace ExchangeRatesAPI.Models
{
    public class ExchangeDatabaseSettings : IExchangeDatabaseSettings
    {
        public string DatabaseName { get; set; }
        public string DatabaseConnectionString { get; set; }
        public string ExchangeRatesCollectionName { get; set; }
}
    public interface IExchangeDatabaseSettings
    {
        string DatabaseName { get; set; }
        string DatabaseConnectionString { get; }
        string ExchangeRatesCollectionName { get; }
    }
}

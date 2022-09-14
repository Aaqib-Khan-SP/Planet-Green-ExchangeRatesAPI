namespace ExchangeRatesAPI.Models
{
    public interface IDBAccess
    {
        public List<DayRate> GetRatesForCurrency();
        public List<ExchangeRates> GetRates();

    }
}

using ExchangeRatesAPI.Models;
using MongoDB.Driver;

namespace ExchangeRatesAPI.DataAccess
{
    public class DBAccess : IDBAccess
    {
        private readonly MongoClient _client;
        private readonly IMongoCollection<ExchangeRate> _exchangeRates;
        public DBAccess(IExchangeDatabaseSettings databaseSettings)
        {
            _client = new MongoClient(databaseSettings.DatabaseConnectionString);
            var database = _client.GetDatabase(databaseSettings.DatabaseName);
            _exchangeRates = database.GetCollection<ExchangeRate>(databaseSettings.ExchangeRatesCollectionName);
        }

        public List<ExchangeRate> GetRates()
        {
            return _exchangeRates.Find(_ => true).ToList();
        }

        public ExchangeRate GetRatesForCurrency(string currencyName, int lastNRecords = 1)
        {
            return _exchangeRates.Find(x => x.CurrencyName == currencyName).FirstOrDefault();
        }

        public List<DayRate> GetRatesForCurrency()
        {
            throw new NotImplementedException();
        }
    }
}

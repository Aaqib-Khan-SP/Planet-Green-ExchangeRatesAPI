using ExchangeRatesAPI.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ExchangeRatesAPI.Services
{
    public class ExchangeRatesService : IExchangeRates
    {
        private readonly ExchangeRatesDBContext _context;
        private readonly IMapper _mapper;
        public ExchangeRatesService(ExchangeRatesDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExchangeRates>> GetExchangeRates(string currencyCode, string date)
        {
            try
            {
                var data = _context.ExchangeRates.Where(x => (date != null ? x.Date == date : true) && (currencyCode != null ? x.CurrencyCode == currencyCode : true));
                if (data == null)
                {
                    return null;
                }
                List<ExchangeRate> allRates = _mapper.Map<List<ExchangeRate>>(data);

                return FormatResponseObject(allRates);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<ExchangeRates> FormatResponseObject(List<ExchangeRate> allRates)
        {
            List<ExchangeRates> rates = new List<ExchangeRates>();
            var currencies = allRates.GroupBy(p => p.CurrencyCode).Select(g => g.First().CurrencyCode).ToList();
            foreach(var currency in currencies)
            {
                rates.Add(new ExchangeRates{ CurrencyCode = currency,Rates = allRates.Where(r => r.CurrencyCode == currency).ToList()});
                
            }
            rates.ForEach(x => x.Rates.ForEach(y=>y.CurrencyCode = null));
            return rates;
        }

        public async Task<bool> UpsertExchangeRate(string currencyCode, decimal rate, string date)
        {
            try
            {
                var entity = await _context.ExchangeRates.SingleOrDefaultAsync(x => x.Date == date && x.CurrencyCode == currencyCode);
                if (entity == null)
                {
                    ExchangeRateEntity currencyRate = new ExchangeRateEntity()
                    {
                        Date = DateTime.Today.ToString("d"),
                        Rate = rate,
                        CurrencyCode = currencyCode
                    };
                    var data = _context.ExchangeRates.Add(currencyRate);
                }
                else
                {
                    entity.Rate = rate;
                    _context.ExchangeRates.Update(entity);
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

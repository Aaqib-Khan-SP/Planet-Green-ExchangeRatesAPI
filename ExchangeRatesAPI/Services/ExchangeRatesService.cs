using ExchangeRatesAPI.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ExchangeRatesAPI.Services
{
    public class ExchangeRatesService : IExchangeRates
    {
        private readonly ExchangeRatesDBContext _context;
        private readonly IMapper _mapper;
        public ExchangeRatesService(ExchangeRatesDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExchangeRate?> GetExchangeRates(string currencyCode)
        {
            var data = await _context.ExchangeRates.SingleOrDefaultAsync(x => x.CurrencyCode == currencyCode);
            if (data == null)
            {
                return null;
            }
            return _mapper.Map<ExchangeRate>(data);
        }
    }
}

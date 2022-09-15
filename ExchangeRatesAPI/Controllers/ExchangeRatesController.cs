using ExchangeRatesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExchangeRatesAPI.Services;

namespace ExchangeRatesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeRatesController : ControllerBase
    {
        public readonly IExchangeRates _exchangeRatesService;
        public ExchangeRatesController(IExchangeRates exchangeRatesService)
        {
            _exchangeRatesService = exchangeRatesService;
        }

        [HttpGet(Name = nameof(GetExchangeRatesForCurrency))]
        public async Task<ActionResult<ExchangeRate>> GetExchangeRatesForCurrency([FromQuery] string currencyCode)
        {
            var data = _exchangeRatesService.GetExchangeRates(currencyCode).GetAwaiter().GetResult();
            if (data == null)
            {
                return NotFound();
            }
            var resource = new ExchangeRate
            {
                Href = Url.Link(nameof(GetExchangeRatesForCurrency), new { currencyCode = currencyCode }),
                CurrencyCode = currencyCode,
                CurrencyName = data.CurrencyName,
                Rates = data.Rates
            };
            return resource;
        }

    }
}
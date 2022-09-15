using ExchangeRatesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExchangeRatesAPI.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ExchangeRatesAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ExchangeRatesController : ControllerBase
    {
        public readonly IExchangeRates _exchangeRatesService;
        public ExchangeRatesController(IExchangeRates exchangeRatesService)
        {
            _exchangeRatesService = exchangeRatesService;
        }

        [HttpGet(Name = nameof(GetExchangeRates))]
        public async Task<ActionResult<ExchangeRate>> GetExchangeRates([FromQuery] string? currencyCode, string? date)
        {
            var data = _exchangeRatesService.GetExchangeRates(currencyCode, date).GetAwaiter().GetResult();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost(Name = nameof(InsertRate))]
        public async Task<ActionResult<ExchangeRate>> InsertRate(string currencyCode, decimal rate, string date)
        {
            var response = _exchangeRatesService.InsertExchangeRate(currencyCode, rate, date);
            if (!response.Result)
            {
                return BadRequest("Error inserting rate");
            }
            return Ok("Insert Successfull");
        }

    }
}
using ExchangeRatesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExchangeRatesAPI.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ExchangeRatesAPI.Filters;
using Microsoft.AspNetCore.Authorization;

namespace ExchangeRatesAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    [TokenAuthenticationFilter]
    public class ExchangeRatesController : ControllerBase
    {
        public readonly IExchangeRates _exchangeRatesService;
        private readonly IAuth _auth;
        public ExchangeRatesController(IExchangeRates exchangeRatesService, IAuth auth)
        {
            _exchangeRatesService = exchangeRatesService;
            _auth = auth;
        }

        [HttpGet(Name = nameof(GetExchangeRates))]
        public async Task<ActionResult<ExchangeRate>> GetExchangeRates([FromQuery] string? currencyCode, string? date)
        {
            var userId = "";
            var token = Request.Headers["Authorization"];
            try
            {
                userId = _auth.UserIdFromToken(token);
                if (userId == null)
                {
                    throw new UnauthorizedAccessException();
                }
                var data = _exchangeRatesService.GetExchangeRates(currencyCode, date).GetAwaiter().GetResult();
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (UnauthorizedAccessException ex) { throw; }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

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
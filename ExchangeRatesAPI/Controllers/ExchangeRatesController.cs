using Microsoft.AspNetCore.Mvc;

namespace ExchangeRatesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeRatesController : ControllerBase
    {
        public ExchangeRatesController()
        {
            
        }

        [HttpGet(Name = nameof(GetExchangeRates))]
        public IActionResult GetExchangeRates()
        {
            throw new NotImplementedException();
        }

    }
}
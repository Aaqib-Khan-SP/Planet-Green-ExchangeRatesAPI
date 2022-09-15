using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRatesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new
            {
                href = Url.Link(nameof(GetRoot), null),
                currency = new
                {
                    href = Url.Link(nameof(ExchangeRatesController.GetExchangeRatesForCurrency),null)
                }
            };
            return Ok(response);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExchangeRatesAPI.Models
{
    public class ExchangeRateEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Date { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Rate { get; set; }
    }
}

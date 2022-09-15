using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ExchangeRatesAPI.Models
{
    public class ExchangeRate
    {
        public string Date { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CurrencyCode { get; set; }
        public decimal Rate { get; set; }
    }
}

using Newtonsoft.Json;

namespace ExchangeRatesAPI.Models
{
    public abstract class Resource
    {
        [JsonProperty(Order = -2)]
        public string Href { get; set; }
    }
}

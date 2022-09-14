using Newtonsoft.Json;

namespace ExchangeRatesAPI.Models
{
    public abstract class Resource
    {
        [JsonProperty(Order = -1)]
        public string Href { get; set; }
    }
}

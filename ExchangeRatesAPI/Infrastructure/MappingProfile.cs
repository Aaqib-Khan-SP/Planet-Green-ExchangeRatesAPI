using AutoMapper;
using ExchangeRatesAPI.Models;

namespace ExchangeRatesAPI.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ExchangeRateEntity, ExchangeRate>();
        }
    }
}

using ExchangeRatesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExchangeRatesAPI
{
    public class ExchangeRatesDBContext : DbContext
    {
        public ExchangeRatesDBContext(DbContextOptions options) :base(options)
        {
        }
        public DbSet<ExchangeRateEntity> ExchangeRates { get; set; }

    }
}

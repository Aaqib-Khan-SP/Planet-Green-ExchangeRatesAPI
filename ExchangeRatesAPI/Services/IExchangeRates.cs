﻿using ExchangeRatesAPI.Models;

namespace ExchangeRatesAPI.Services
{
    public interface IExchangeRates
    {
        Task<IEnumerable<ExchangeRates>> GetExchangeRates(string currencyCode, string date);
        Task<bool> InsertExchangeRate(string currencyCode, decimal rate, string date);
    }
}

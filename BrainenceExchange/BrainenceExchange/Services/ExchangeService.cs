using BrainenceExchange.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainenceExchange.Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly ICurrencyDataService currencyData;
        private readonly IDataRepository repository;

        public ExchangeService(ICurrencyDataService currencyData, IDataRepository repository)
        {
            this.currencyData = currencyData;
            this.repository = repository;
        }

        public async Task<double> ExchangeAsync(string from, string to, double amount)
        {
            var rates = await currencyData.GetCurrencyDataAsync(from);
            if (rates.ContainsKey(to))
            {
                var result = amount * rates[to];
                await repository.SaveEntryAsync(new ExchangeEntry() { FromCurrencyCode = from, FromAmount = amount, ToCurrencyCode = to, ToAmount = result, Date = DateTime.UtcNow });
                return result;
            }
            else
            {
                return 0;
            }
        }
    }
}

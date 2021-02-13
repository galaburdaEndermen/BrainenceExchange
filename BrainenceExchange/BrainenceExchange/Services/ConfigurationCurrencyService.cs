using BrainenceExchange.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainenceExchange.Services
{
    //https://stackoverflow.com/questions/41329108/asp-net-core-get-json-array-using-iconfiguration
    public class ConfigurationCurrencyService : ICurrencyService
    {
        private List<Currency> currencies = new List<Currency>();

        public ConfigurationCurrencyService(IConfiguration configuration)
        {
            IConfigurationSection CurrenciesSection = configuration.GetSection("Currencies");
            var Currencies = CurrenciesSection.GetChildren().ToDictionary(x => x.Key, x => x.Value);
            foreach (var currency in Currencies)
            {
                currencies.Add(new Currency() { Code = currency.Key, Picture = currency.Value });
            }
        }

        public IEnumerable<Currency> GetAllCurrencies()
        {
            return currencies;
        }

        public Currency GetCurrencyByCode(string code)
        {
            return currencies.FirstOrDefault(currency => currency.Code == code);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace BrainenceExchange.Services
{
    public class ExchangeRatesApiCurrencyDataService : ICurrencyDataService
    {
        static HttpClient client = new HttpClient();
        static string url = "https://api.exchangeratesapi.io/latest?base=";

        public async Task<Dictionary<string, double>> GetCurrencyDataAsync(string Base)
        {
            HttpResponseMessage response = await client.GetAsync(url + Base);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var rates = JsonSerializer.Deserialize<ExchangeRatesApiResponse>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).Rates;
                return rates;
            }
            else
            {
                return null;
            }
        }

        private class ExchangeRatesApiResponse
        {
            public Dictionary<string, double> Rates { get; set; }

            public string Base { get; set; }
        }
    }
}

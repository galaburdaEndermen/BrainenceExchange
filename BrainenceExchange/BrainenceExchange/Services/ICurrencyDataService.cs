using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainenceExchange.Services
{
    public interface ICurrencyDataService
    {
        Task<Dictionary<string, double>> GetCurrencyDataAsync(string Base);
    }
}

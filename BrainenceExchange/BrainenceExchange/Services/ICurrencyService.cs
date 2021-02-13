using BrainenceExchange.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainenceExchange.Services
{
    public interface ICurrencyService
    {
        IEnumerable<Currency> GetAllCurrencies();

        Currency GetCurrencyByCode(string code);
    }
}

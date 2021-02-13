using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainenceExchange.Services
{
    public interface IExchangeService
    {
        Task<double> ExchangeAsync(string from, string to, double amount);
    }
}

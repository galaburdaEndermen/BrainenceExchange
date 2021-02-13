using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainenceExchange.Models.Queries
{
    public class ExchangeQuery
    {
        public string FromCurrencyCode { get; set; }

        public double Amount { get; set; }

        public string ToCurrencyCode { get; set; }
    }
}

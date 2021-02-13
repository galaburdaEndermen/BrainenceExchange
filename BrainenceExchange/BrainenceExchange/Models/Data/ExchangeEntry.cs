using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainenceExchange.Models.Data
{
    public class ExchangeEntry
    {
        public Guid Id { get; set; }

        public string FromCurrencyCode { get; set; }

        public double FromAmount { get; set; }

        public string ToCurrencyCode { get; set; }

        public double ToAmount { get; set; }

        public DateTime Date { get; set; }
    }
}

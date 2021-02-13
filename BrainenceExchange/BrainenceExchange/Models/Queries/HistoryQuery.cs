using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainenceExchange.Models.Queries
{
    public class HistoryQuery
    {
        public IEnumerable<string> FromCurrencyCodes { get; set; }

        public IEnumerable<string> ToCurrencyCodes { get; set; }

        public DateTime Date { get; set; }

        public string OrderColumnName { get; set; }

        public bool IsDescending { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}

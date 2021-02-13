using BrainenceExchange.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainenceExchange.Models.QueriesResults
{
    public class HistoryQueryResult
    {
        public IEnumerable<ExchangeEntry> Entries { get; set; }

        public int Count { get; set; }
    }
}

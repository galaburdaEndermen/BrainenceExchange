using BrainenceExchange.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainenceExchange.Models.Data
{
    public interface IDataRepository
    {
        Task<(List<ExchangeEntry> entries, int count)> GetEntriesAsync(HistoryQuery query);

        Task SaveEntryAsync(ExchangeEntry entry);
    }
}

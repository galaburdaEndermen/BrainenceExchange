using BrainenceExchange.Models.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainenceExchange.Models.Data
{
    public class PsqlDataRepository : IDataRepository
    {
        private readonly ApplicationDbContext context;

        public PsqlDataRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<(List<ExchangeEntry> entries, int count)> GetEntriesAsync(HistoryQuery query)
        {
            var entries = context.ExchangeEntries.Where(entry => query.FromCurrencyCodes.Contains(entry.FromCurrencyCode) && query.ToCurrencyCodes.Contains(entry.ToCurrencyCode));

            var orderedEntries = query.OrderColumnName switch
            {
                "FromCurrencyCode" => entries.OrderBy(c => c.FromCurrencyCode),
                "FromAmount" => entries.OrderBy(c => c.FromAmount),
                "ToCurrencyCode" => entries.OrderBy(c => c.ToCurrencyCode),
                "ToAmount" => entries.OrderBy(c => c.ToAmount),
                "Date" => entries.OrderBy(c => c.Date),
                _ => entries
            };

            if (query.IsDescending)
            {
                orderedEntries = orderedEntries.Reverse();
            }
            var selectedEntries = await orderedEntries.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize).ToListAsync();
            return (entries: selectedEntries, count: entries.Count());
        }

        public async Task SaveEntryAsync(ExchangeEntry entry)
        {
            context.ExchangeEntries.Add(entry);
            await context.SaveChangesAsync();
        }
    }
}

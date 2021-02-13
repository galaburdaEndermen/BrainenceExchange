using BrainenceExchange.Models.Data;
using BrainenceExchange.Models.Queries;
using BrainenceExchange.Models.QueriesResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainenceExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IDataRepository repository;

        public HistoryController(IDataRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("")]
        public async Task<ActionResult<HistoryQueryResult>> GetAll([FromQuery] HistoryQuery query)
        {
            //https://stackoverflow.com/questions/748062/return-multiple-values-to-a-method-caller/36436255#36436255
            (List<ExchangeEntry> entries, int count) = await repository.GetEntriesAsync(query);

            var result = new HistoryQueryResult()
            {
                Entries = entries,
                Count = count
            };
            return Ok(result);
        }
    }
}

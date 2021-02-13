using BrainenceExchange.Models.Queries;
using BrainenceExchange.Services;
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
    public class ExchangeController : ControllerBase
    {
        private readonly IExchangeService exchangeService;

        public ExchangeController(IExchangeService exchangeService)
        {
            this.exchangeService = exchangeService;
        }

        [HttpGet("")]
        public async Task<ActionResult<double>> Exchange([FromQuery] ExchangeQuery query)
        {
            var result = await exchangeService.ExchangeAsync(query.FromCurrencyCode, query.ToCurrencyCode, query.Amount);
            return Ok(result);
        }
    }
}

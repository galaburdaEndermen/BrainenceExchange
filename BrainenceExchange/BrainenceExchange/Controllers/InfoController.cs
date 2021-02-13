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
    public class InfoController : ControllerBase
    {
        private readonly ICurrencyService currencyService;

        public InfoController(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }

        [HttpGet("AvailableCurrency")]
        public IActionResult AvailableCurrency()
        {
            var AllCurrencies = currencyService.GetAllCurrencies().Select(currency => currency.Code);
            return Ok(AllCurrencies);
        }
    }
}

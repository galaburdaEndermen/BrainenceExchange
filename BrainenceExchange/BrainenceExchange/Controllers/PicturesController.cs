using BrainenceExchange.Models.Data;
using BrainenceExchange.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly ICurrencyService currencyService;

        public PicturesController(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }

        [HttpGet("Get/{code}")]
        public IActionResult GetByCode(string code)
        {
            var currency = currencyService.GetCurrencyByCode(code);
            if (currency == null)
            {
                return File(System.IO.File.OpenRead(Currency.DefaultPath), "image/png");
            }

            var file = System.IO.File.OpenRead(currency.Path);
            return File(file, "image/png");
        }
    }
}

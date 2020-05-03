using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrgLive.QuotingEngine.Application.Interfaces;
using OrgLive.QuotingEngine.Application.Models;
using OrgLive.QuotingEngine.Domain.Models;

namespace OrgLive.QuotingEngine.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;

        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        // GET api/banking
        [HttpGet]
        public ActionResult<IEnumerable<Quote>> Get()
        {
            return Ok(_quoteService.GetQuotes());
        }
    }
}

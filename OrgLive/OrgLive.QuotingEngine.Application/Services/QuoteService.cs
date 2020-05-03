using OrgLive.Domain.Core.Bus;
using OrgLive.QuotingEngine.Application.Interfaces;
using OrgLive.QuotingEngine.Domain.Interfaces;
using OrgLive.QuotingEngine.Domain.Models;
using System.Collections.Generic;

namespace OrgLive.QuotingEngine.Application.Services
{
    public class QuoteService: IQuoteService
    {
        private readonly IEventBus _bus;
        private readonly IQuoteRepository _quoteRepository;

        public QuoteService(IEventBus bus,
            IQuoteRepository quoteRepository)
        {
            _bus = bus;
            _quoteRepository = quoteRepository;
        }

        public IEnumerable<Quote> GetQuotes()
        {
            return _quoteRepository.GetQuotes();
        }
    }
}

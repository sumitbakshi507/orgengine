using OrgLive.QuotingEngine.Data.Context;
using OrgLive.QuotingEngine.Domain.Interfaces;
using OrgLive.QuotingEngine.Domain.Models;
using System.Collections.Generic;

namespace OrgLive.QuotingEngine.Data.Repository
{
    public class QuoteRepository: IQuoteRepository
    {
        private QuoteDbContext _ctx;

        public QuoteRepository(QuoteDbContext ctx)
        {
            _ctx = ctx;
        }
        public void Add(Quote quote)
        {
            _ctx.Quotes.Add(quote);
            _ctx.SaveChanges();
        }

        public IEnumerable<Quote> GetQuotes()
        {
            return _ctx.Quotes;
        }
    }
}

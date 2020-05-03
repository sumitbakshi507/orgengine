using OrgLive.QuotingEngine.Domain.Models;
using System.Collections.Generic;

namespace OrgLive.QuotingEngine.Domain.Interfaces
{
    public interface IQuoteRepository
    {
        IEnumerable<Quote> GetQuotes();

        void Add(Quote quote);
    }
}

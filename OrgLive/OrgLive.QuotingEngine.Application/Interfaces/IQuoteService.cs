using OrgLive.QuotingEngine.Application.Models;
using OrgLive.QuotingEngine.Domain.Models;
using System.Collections.Generic;

namespace OrgLive.QuotingEngine.Application.Interfaces
{
    public interface IQuoteService
    {
        IEnumerable<Quote> GetQuotes();
    }
}

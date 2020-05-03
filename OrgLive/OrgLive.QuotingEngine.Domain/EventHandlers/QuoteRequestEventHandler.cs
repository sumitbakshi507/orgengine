using OrgLive.Domain.Core.Bus;
using OrgLive.QuotingEngine.Domain.Events;
using OrgLive.QuotingEngine.Domain.Interfaces;
using OrgLive.QuotingEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgLive.QuotingEngine.Domain.EventHandlers
{
    public class QuoteRequestEventHandler : IEventHandler<QuoteRequestCreatedEvent>
    {
        private readonly IQuoteRepository _quoteRepository;

        public QuoteRequestEventHandler(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        public Task Handle(QuoteRequestCreatedEvent @event)
        {
            // Sequence Should be used
            var prefixNumber = DateTime.Now.ToString("DDMMYYYY");
            var lastQuote = _quoteRepository.GetQuotes()
                .OrderByDescending(z => z.QuoteNumber)
                .FirstOrDefault(t => t.QuoteNumber.StartsWith(prefixNumber));
            var quoteNumber = String.Empty;


            if (lastQuote == null)
            {
                quoteNumber = prefixNumber + "_0000001";
            }
            else
            {
                var lastNumber = Convert.ToInt32(lastQuote.QuoteNumber.Replace(prefixNumber + "_", ""));
                lastNumber = lastNumber + 1;
                quoteNumber = lastNumber.ToString();
                while (quoteNumber.Length < 7) {
                    quoteNumber = "0" + quoteNumber;
                }

                quoteNumber = prefixNumber + "_" + quoteNumber;
            }

            _quoteRepository.Add(new Quote()
            {
                ProductName = @event.ProductName,
                Version = @event.Version,
                QuoteNumber = quoteNumber,
                QuoteDate = DateTime.Now,
                StartDate = @event.StartDate,
                EndDate = @event.EndDate
            });

            return Task.CompletedTask;
        }
    }
}

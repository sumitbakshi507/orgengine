using OrgLive.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrgLive.QuotingEngine.Domain.Events
{
    public class QuoteRequestCreatedEvent : Event
    {
        public string ProductName { get; set; }

        public string Version { get; set; }

        public QuoteRequestCreatedEvent(string productName, int version)
        {
            ProductName = productName;
            Version = version;
        }
    }
}

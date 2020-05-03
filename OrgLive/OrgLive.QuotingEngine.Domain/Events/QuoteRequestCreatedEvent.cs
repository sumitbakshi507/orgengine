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

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public QuoteRequestCreatedEvent(string productName, string version, DateTime startDate)
        {
            ProductName = productName;
            Version = version;
            StartDate = startDate;
            EndDate = startDate.AddYears(1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OrgLive.QuotingEngine.Domain.Models
{
    public class Quote
    {
        public int Id { get; set; }

        public string QuoteNumber { get; set; }

        public string ProductName { get; set; }

        public string Version { get; set; }

        public DateTime QuoteDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}

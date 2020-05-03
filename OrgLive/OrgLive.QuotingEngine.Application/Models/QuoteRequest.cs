using System;
using System.Collections.Generic;
using System.Text;

namespace OrgLive.QuotingEngine.Application.Models
{
    public class QuoteRequest
    {
        public string ProductName { get; set; }

        public int Version { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using OrgLive.QuotingEngine.Domain.Models;

namespace OrgLive.QuotingEngine.Data.Context
{
    public class QuoteDbContext : DbContext
    {
        public QuoteDbContext(DbContextOptions options) : base(options)
        {
        }

        // Add DBSet<Table> Properties Here 
        public DbSet<Quote> Quotes { get; set; }
    }
}

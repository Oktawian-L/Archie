using Archie.Migrations;
using Archie.Models;
using Microsoft.EntityFrameworkCore;

namespace Archie.Data
{
    public class SyrakuzaContext : DbContext
    {
        public SyrakuzaContext(DbContextOptions<SyrakuzaContext> options) : base(options)
        {

        }
        public DbSet<Spots> Spots { get; set; }
        //public DbSet<SpotsAPI>  SpotsAPI { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<Ticker> Tickers { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
    }
}


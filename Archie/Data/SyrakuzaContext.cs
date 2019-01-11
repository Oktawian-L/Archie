using Archie.Migrations;
using Archie.Models;
using Microsoft.EntityFrameworkCore;

namespace Archie.Data
{
    public class SyrakuzaContext : DbContext
    {
        private string v;
        public SyrakuzaContext(DbContextOptions<SyrakuzaContext> options) : base(options)
        {

        }
        public SyrakuzaContext(string v)
        {
            this.v = v;
        }
        public DbSet<Spots> Spots { get; set; }
        //public DbSet<SpotsAPI>  SpotsAPI { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<Ticker> Tickers { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=archie;Trusted_Connection=True;ConnectRetryCount=0");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SpotsEntityTypeConfiguration());
            builder.ApplyConfiguration(new TradesTypeEntityTypeConfiguration());
            builder.ApplyConfiguration(new TickersItemEntityTypeConfiguration());
            builder.ApplyConfiguration(new ExchangeRatesItemEntityTypeConfiguration());

        }

    }
}


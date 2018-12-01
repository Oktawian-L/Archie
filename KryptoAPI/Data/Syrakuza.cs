namespace KryptoAPI.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Syrakuza : DbContext
    {
        public Syrakuza()
            : base("name=Syrakuza")
        {
        }

        public virtual DbSet<ExchangeRates> ExchangeRates { get; set; }
        public virtual DbSet<Spots> Spots { get; set; }
        public virtual DbSet<SpotsAPI> SpotsAPI { get; set; }
        public virtual DbSet<Tickers> Tickers { get; set; }
        public virtual DbSet<TickerStorage> TickerStorage { get; set; }
        public virtual DbSet<Trades> Trades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

namespace GoldAPI.Data
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

        public virtual DbSet<C__EFMigrationsHistory> C__EFMigrationsHistory { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<ExchangeRates> ExchangeRates { get; set; }
        public virtual DbSet<Spots> Spots { get; set; }
        public virtual DbSet<SpotsAPI> SpotsAPI { get; set; }
        public virtual DbSet<Tickers> Tickers { get; set; }
        public virtual DbSet<TickerStorage> TickerStorage { get; set; }
        public virtual DbSet<Trades> Trades { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.start_ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.end_ip_address)
                .IsUnicode(false);
        }
    }
}

using Archie.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Archie.Data
{
    internal class TickersItemEntityTypeConfiguration : IEntityTypeConfiguration<Ticker>
    {
        public void Configure(EntityTypeBuilder<Ticker> builder)
        {
            builder.ToTable("Tickers");

            builder.HasKey(ci => ci.Id);

            /*builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("ticker_hilo")
               .IsRequired();*/
            builder.Property(cb => cb.low)
                .IsRequired();
            builder.Property(cb => cb.high)
                .IsRequired();
            builder.Property(cb => cb.vwap)
                .IsRequired();
            builder.Property(cb => cb.volume)
                .IsRequired();
            builder.Property(cb => cb.last)
            .IsRequired();
            builder.Property(cb => cb.ask)
                .IsRequired();
            builder.Property(cb => cb.bid)
                .IsRequired();
        }
    }
}
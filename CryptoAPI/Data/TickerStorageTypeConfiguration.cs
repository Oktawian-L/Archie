using Archie.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CryptoAPI.Models
{
    internal class TickerStorageTypeConfiguration : IEntityTypeConfiguration<TickerStorage>
    {
        public void Configure(EntityTypeBuilder<TickerStorage> builder)
        {
            builder.ToTable("TickerStorage");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("tickerstorage_hilo")
               .IsRequired();
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

      /*  public void Configure(EntityTypeBuilder<object> builder)
        {
            throw new System.NotImplementedException();
        }*/
    }
}
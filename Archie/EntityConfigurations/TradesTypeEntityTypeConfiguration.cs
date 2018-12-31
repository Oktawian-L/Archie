using Archie.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Archie.Data
{
    internal class TradesTypeEntityTypeConfiguration : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder.ToTable("Trades");

            builder.HasKey(ci => ci.Id);

            /*builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("trade_hilo")
               .IsRequired();*/
            builder.Property(cb => cb.transactionTime)
                .IsRequired();
            builder.Property(cb => cb.amount)
                .IsRequired();
            builder.Property(cb => cb.closeRate)
                .IsRequired();
            builder.Property(cb => cb.rate)
                .IsRequired();
        }

    }
}
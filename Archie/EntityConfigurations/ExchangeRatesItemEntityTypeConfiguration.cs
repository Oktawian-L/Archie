using Archie.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Archie.Data
{
    internal class ExchangeRatesItemEntityTypeConfiguration : IEntityTypeConfiguration<ExchangeRate>
    {
        public void Configure(EntityTypeBuilder<ExchangeRate> builder)
        {
            builder.ToTable("ExchangeRates");

            builder.HasKey(ci => ci.Id);

            /*builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("exchangerates_hilo")
               .IsRequired();*/
       
            builder.Property(cb => cb.dateInput)
                .IsRequired();
            builder.Property(cb => cb.PLN)
                .IsRequired();
            builder.Property(cb => cb.EUR)
                .IsRequired();
            builder.Property(cb => cb.GBP)
           .IsRequired();
  
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Archie.Models;

namespace Archie.Data
{
    internal class SpotsEntityTypeConfiguration : IEntityTypeConfiguration<Spots>
    {
        public void Configure(EntityTypeBuilder<Spots> builder)
        {
            builder.ToTable("Spots");

            builder.HasKey(ci => ci.Id);

            /*builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("spot_hilo")
               .IsRequired();*/
            builder.Property(cb => cb.dateInput)
                .IsRequired();
            builder.Property(cb => cb.goldVal)
                .IsRequired();
            builder.Property(cb => cb.silverVal)
                .IsRequired();
            builder.Property(cb => cb.platiniumVal)
                .IsRequired();
        }
    }
}
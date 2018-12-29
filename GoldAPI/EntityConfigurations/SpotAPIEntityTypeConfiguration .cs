
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldAPI
{
    public class SpotAPIEntityTypeConfiguration : IEntityTypeConfiguration<SpotAPI>
    {
        public void Configure(EntityTypeBuilder<SpotAPI> builder)
        {
            builder.ToTable("SpotAPItable");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("spotapi_hilo")
               .IsRequired();
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

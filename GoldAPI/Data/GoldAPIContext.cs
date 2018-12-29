using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GoldAPI
{
    public class CatalogContext : DbContext
    {
        private string v;

        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        public CatalogContext(string v)
        {
            this.v = v;
        }

        public DbSet<SpotAPI> SpotAPI { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=sqldb,1433;Initial Catalog=archie;Database=archie;User Id=sa;Password=5uP3RC0mpl3Xp@55w0rD");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SpotAPIEntityTypeConfiguration());
            //builder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());
            //builder.ApplyConfiguration(new CatalogItemEntityTypeConfiguration());
        }
    }


    public class CatalogContextDesignFactory : IDesignTimeDbContextFactory<CatalogContext>
    {
        public CatalogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>()
                .UseSqlServer("Server=.;Initial Catalog=Microsoft.eShopOnContainers.Services.CatalogDb;Integrated Security=true");

            return new CatalogContext(optionsBuilder.Options);
        }
    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Archie.Models;

namespace CryptoAPI.Models
{
    public class CryptoAPIContext : DbContext
    {
        public CryptoAPIContext (DbContextOptions<CryptoAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Archie.Models.TickerStorage> TickerStorage { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=sqldb,1433;Initial Catalog=archie;Database=archie;User Id=sa;Password=5uP3RC0mpl3Xp@55w0rD");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TickerStorageTypeConfiguration());

        }

    }
}

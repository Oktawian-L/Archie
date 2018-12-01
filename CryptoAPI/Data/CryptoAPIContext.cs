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
    }
}

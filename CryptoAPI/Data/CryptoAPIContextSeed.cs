using Archie.Models;
using CryptoAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAPI.Data
{
    public class CryptoAPIContextSeed
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {
            var context = (CryptoAPIContext)applicationBuilder
                .ApplicationServices.GetService(typeof(CryptoAPIContext));
            using (context)
            {
                context.Database.Migrate();
                if (!context.TickerStorage.Any())
                {
                    context.TickerStorage.AddRange(
                        GetPreconfiguredSpots());
                    await context.SaveChangesAsync();
                }
            }
        }

        static IEnumerable<TickerStorage> GetPreconfiguredSpots()
        {
            return new List<TickerStorage>()
            {
             //new TickerStorage(){Id =1 ,low = 1,high = 0,vwap = 0,volume = 0,last = 0,ask = 0,bid = 0 },
            // new TickerStorage(){low = 11,high = 12,vwap = 13,volume = 41,last = 15,ask = 6,bid = 17 },
            };
        }
   
    }
}

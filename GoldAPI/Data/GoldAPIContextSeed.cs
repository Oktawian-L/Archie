
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GoldAPI
{
    public class GoldAPIContextSeed
    {

        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {
            var context = (CatalogContext)applicationBuilder
                .ApplicationServices.GetService(typeof(CatalogContext));
           using (context)
            {
                context.Database.Migrate();
                if (!context.SpotAPI.Any())
                {
                    context.SpotAPI.AddRange(
                        GetPreconfiguredSpots());
                    await context.SaveChangesAsync();
                }
            }
        }

        static IEnumerable<SpotAPI> GetPreconfiguredSpots()
        {
            return new List<SpotAPI>()
            {
            new SpotAPI(){dateInput = System.DateTime.Now, goldVal = 1,silverVal=2,platiniumVal = 3 },
            new SpotAPI(){dateInput = System.DateTime.Now, goldVal = 11,silverVal=12,platiniumVal = 33 },
            };
        }

        /*internal static async Task<object> SeedAsync( IApplicationBuilder applicationBuilder)
        {


            // throw new NotImplementedException();
            var context = (CatalogContext)applicationBuilder
               .ApplicationServices.GetService(typeof(CatalogContext));
            using (context)
             {
                 context.Database.Migrate();
                 if (!context.SpotAPI.Any())
                 {
                     context.SpotAPI.AddRange(
                         GetPreconfiguredSpots());
                     await context.SaveChangesAsync();
                 }
             }

        }*/
    }
}

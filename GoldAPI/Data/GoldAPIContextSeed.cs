
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
            new SpotAPI(){dateInput = new DateTime(2018,8,24), goldVal = 1285.12M,silverVal=16.93M,platiniumVal = 979.10M },
            new SpotAPI(){dateInput = new DateTime(2018,8,23), goldVal = 1286.45M,silverVal=17.06M,platiniumVal = 982.60M },
            new SpotAPI(){dateInput = new DateTime(2018,8,22), goldVal = 1285.10M,silverVal=16.93M,platiniumVal = 980.90M },
            new SpotAPI(){dateInput = new DateTime(2018,8,21), goldVal = 1287.60M,silverVal=17.02M,platiniumVal = 981.30M },
            new SpotAPI(){dateInput = new DateTime(2018,8,18), goldVal = 1295.25M,silverVal=17.15M,platiniumVal = 985.50M },
            new SpotAPI(){dateInput = new DateTime(2018,8,17), goldVal = 1285.90M,silverVal=17.02M,platiniumVal = 982.40M },
            new SpotAPI(){dateInput = new DateTime(2018,8,16), goldVal = 1270.15M,silverVal=16.68M,platiniumVal = 981.70M },
            new SpotAPI(){dateInput = new DateTime(2018,8,15), goldVal = 1274.60M,silverVal=16.89M,platiniumVal = 974.50M },
            new SpotAPI(){dateInput = new DateTime(2018,8,14), goldVal = 1281.10M,silverVal=16.97M,platiniumVal = 967.40M },
            new SpotAPI(){dateInput = new DateTime(2018,8,11), goldVal = 1288.30M,silverVal=17.09M,platiniumVal = 974.90M },
            new SpotAPI(){dateInput = new DateTime(2018,8,10), goldVal = 1278.90M,silverVal=17.08M,platiniumVal = 989.70M },
            new SpotAPI(){dateInput = new DateTime(2018,8,9), goldVal = 1267.95M,silverVal=16.59M,platiniumVal = 985.90M },
            new SpotAPI(){dateInput = new DateTime(2018,8,8), goldVal = 1261.45M,silverVal=16.39M,platiniumVal = 976.10M },
            new SpotAPI(){dateInput = new DateTime(2018,8,7), goldVal = 1257.55M,silverVal=16.13M,platiniumVal = 974.50M },
            new SpotAPI(){dateInput = new DateTime(2018,8,4), goldVal = 1269.30M,silverVal=16.70M,platiniumVal = 971.60M },
            new SpotAPI(){dateInput = new DateTime(2018,8,3), goldVal = 1261.80M,silverVal=16.47M,platiniumVal = 969.00M },
            new SpotAPI(){dateInput = new DateTime(2018,8,2), goldVal = 1266.65M,silverVal=16.67M,platiniumVal = 964.60M },
            new SpotAPI(){dateInput = new DateTime(2018,8,1), goldVal = 1267.05M,silverVal=16.74M,platiniumVal = 953.80M },
            new SpotAPI(){dateInput = new DateTime(2018,7,31), goldVal = 1266.35M,silverVal=16.76M,platiniumVal = 949.50M },
            new SpotAPI(){dateInput = new DateTime(2018,7,28), goldVal = 1259.60M,silverVal=16.56M,platiniumVal = 940.70M },
            new SpotAPI(){dateInput = new DateTime(2018,7,27), goldVal = 1262.05M,silverVal=16.79M,platiniumVal = 936.60M },
            new SpotAPI(){dateInput = new DateTime(2018,7,26), goldVal = 1245.40M,silverVal=16.37M,platiniumVal = 926.40M },
            new SpotAPI(){dateInput = new DateTime(2018,7,25), goldVal = 1252.05M,silverVal=16.31M,platiniumVal = 922.70M },
            new SpotAPI(){dateInput = new DateTime(2018,7,26), goldVal = 1255.55M,silverVal=16.50M,platiniumVal = 931.80M },
            new SpotAPI(){dateInput = new DateTime(2018,7,25), goldVal = 1247.25M,silverVal=16.43M,platiniumVal = 932.30M },
            new SpotAPI(){dateInput = new DateTime(2018,7,20), goldVal = 1236.55M,silverVal=16.18M,platiniumVal = 937.40M },
            new SpotAPI(){dateInput = new DateTime(2018,7,19), goldVal = 1239.85M,silverVal=16.23M,platiniumVal = 932.30M },
            new SpotAPI(){dateInput = new DateTime(2018,7,28), goldVal = 1237.10M,silverVal=16.17M,platiniumVal = 924.20M },
            new SpotAPI(){dateInput = new DateTime(2018,7,17), goldVal = 1229.85M,silverVal=16.07M,platiniumVal = 930.300M },
            new SpotAPI(){dateInput = new DateTime(2018,7,14), goldVal = 1218.95M,silverVal=15.71M,platiniumVal = 930.30M },
            };/*
								
*/
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

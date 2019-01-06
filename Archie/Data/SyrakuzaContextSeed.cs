using Archie.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archie.Data
{
    public class SyrakuzaContextSeed
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {
            var context = (SyrakuzaContext)applicationBuilder
                .ApplicationServices.GetService(typeof(SyrakuzaContext));

            using (context)
            {
                Console.WriteLine("odpalam migracje");
                context.Database.Migrate();
                if (!context.Spots.Any())
                {
                    context.Spots.AddRange(
                        GetPreconfiguredSpots());
                    await context.SaveChangesAsync();
                }
                Console.WriteLine("spoty zsynchronizowane");
                if (!context.Trades.Any())
                {
                    context.Trades.AddRange(
                        GetPreconfiguredTrades());
                    await context.SaveChangesAsync();
                }
                Console.WriteLine("trade zsynchronizowane");
                if (!context.Tickers.Any())
                {
                    context.Tickers.AddRange(
                        GetPreconfiguredTickers());
                    await context.SaveChangesAsync();
                }
                Console.WriteLine("tickers zsynchronizowane");
                if (!context.ExchangeRates.Any())
                {
                    context.ExchangeRates.AddRange(
                        GetPreconfiguredExchangeRates());
                    await context.SaveChangesAsync();
                }
                Console.WriteLine("waluty zsynchronizowane");
            }
            Console.WriteLine("Zamykam Migracje");
        }

        static IEnumerable<Spots> GetPreconfiguredSpots()
        {
            return new List<Spots>()
            {
            new Spots(){dateInput = new DateTime(2018,8,24), goldVal = 1285.12M,silverVal=16.93M,platiniumVal = 979.10M },
            new Spots(){dateInput = new DateTime(2018,8,23), goldVal = 1286.45M,silverVal=17.06M,platiniumVal = 982.60M },
            new Spots(){dateInput = new DateTime(2018,8,22), goldVal = 1285.10M,silverVal=16.93M,platiniumVal = 980.90M },
            new Spots(){dateInput = new DateTime(2018,8,21), goldVal = 1287.60M,silverVal=17.02M,platiniumVal = 981.30M },
            new Spots(){dateInput = new DateTime(2018,8,18), goldVal = 1295.25M,silverVal=17.15M,platiniumVal = 985.50M },
            new Spots(){dateInput = new DateTime(2018,8,17), goldVal = 1285.90M,silverVal=17.02M,platiniumVal = 982.40M },
            new Spots(){dateInput = new DateTime(2018,8,16), goldVal = 1270.15M,silverVal=16.68M,platiniumVal = 981.70M },
            new Spots(){dateInput = new DateTime(2018,8,15), goldVal = 1274.60M,silverVal=16.89M,platiniumVal = 974.50M },
            new Spots(){dateInput = new DateTime(2018,8,14), goldVal = 1281.10M,silverVal=16.97M,platiniumVal = 967.40M },
            new Spots(){dateInput = new DateTime(2018,8,11), goldVal = 1288.30M,silverVal=17.09M,platiniumVal = 974.90M },
            new Spots(){dateInput = new DateTime(2018,8,10), goldVal = 1278.90M,silverVal=17.08M,platiniumVal = 989.70M },
            new Spots(){dateInput = new DateTime(2018,8,9), goldVal = 1267.95M,silverVal=16.59M,platiniumVal = 985.90M },
            new Spots(){dateInput = new DateTime(2018,8,8), goldVal = 1261.45M,silverVal=16.39M,platiniumVal = 976.10M },
            new Spots(){dateInput = new DateTime(2018,8,7), goldVal = 1257.55M,silverVal=16.13M,platiniumVal = 974.50M },
            new Spots(){dateInput = new DateTime(2018,8,4), goldVal = 1269.30M,silverVal=16.70M,platiniumVal = 971.60M },
            new Spots(){dateInput = new DateTime(2018,8,3), goldVal = 1261.80M,silverVal=16.47M,platiniumVal = 969.00M },
            new Spots(){dateInput = new DateTime(2018,8,2), goldVal = 1266.65M,silverVal=16.67M,platiniumVal = 964.60M },
            new Spots(){dateInput = new DateTime(2018,8,1), goldVal = 1267.05M,silverVal=16.74M,platiniumVal = 953.80M },
            new Spots(){dateInput = new DateTime(2018,7,31), goldVal = 1266.35M,silverVal=16.76M,platiniumVal = 949.50M },
            new Spots(){dateInput = new DateTime(2018,7,28), goldVal = 1259.60M,silverVal=16.56M,platiniumVal = 940.70M },
            new Spots(){dateInput = new DateTime(2018,7,27), goldVal = 1262.05M,silverVal=16.79M,platiniumVal = 936.60M },
            new Spots(){dateInput = new DateTime(2018,7,26), goldVal = 1245.40M,silverVal=16.37M,platiniumVal = 926.40M },
            new Spots(){dateInput = new DateTime(2018,7,25), goldVal = 1252.05M,silverVal=16.31M,platiniumVal = 922.70M },
            new Spots(){dateInput = new DateTime(2018,7,26), goldVal = 1255.55M,silverVal=16.50M,platiniumVal = 931.80M },
            new Spots(){dateInput = new DateTime(2018,7,25), goldVal = 1247.25M,silverVal=16.43M,platiniumVal = 932.30M },
            new Spots(){dateInput = new DateTime(2018,7,20), goldVal = 1236.55M,silverVal=16.18M,platiniumVal = 937.40M },
            new Spots(){dateInput = new DateTime(2018,7,19), goldVal = 1239.85M,silverVal=16.23M,platiniumVal = 932.30M },
            new Spots(){dateInput = new DateTime(2018,7,28), goldVal = 1237.10M,silverVal=16.17M,platiniumVal = 924.20M },
            new Spots(){dateInput = new DateTime(2018,7,17), goldVal = 1229.85M,silverVal=16.07M,platiniumVal = 930.300M },
            new Spots(){dateInput = new DateTime(2018,7,14), goldVal = 1218.95M,silverVal=15.71M,platiniumVal = 930.30M },
            };
        }
        static IEnumerable<Trade> GetPreconfiguredTrades()
        {
            return new List<Trade>()
            {
            new Trade(){transactionTime = System.DateTime.Now, amount = 1,closeRate=2,rate= 3 },
            new Trade(){transactionTime = System.DateTime.Now, amount = 11,closeRate=12,rate = 33 },
            new Trade(){transactionTime = new DateTime(2018,8,24), amount = 1285.12M,closeRate=16.93M,rate = 979.10M },
            new Trade(){transactionTime = new DateTime(2018,8,23), amount= 1286.45M,closeRate=17.06M,rate = 982.60M },
            new Trade(){transactionTime = new DateTime(2018,8,22),amount = 1285.10M,closeRate=16.93M,rate = 980.90M },
            new Trade(){transactionTime = new DateTime(2018,8,21), amount = 1287.60M,closeRate=17.02M,rate = 981.30M },
            new Trade(){transactionTime = new DateTime(2018,8,18), amount= 1295.25M,closeRate=17.15M,rate= 985.50M },
            new Trade(){transactionTime = new DateTime(2018,8,17), amount = 1285.90M,closeRate=17.02M,rate = 982.40M },
            new Trade(){transactionTime= new DateTime(2018,8,16), amount= 1270.15M,closeRate=16.68M,rate = 981.70M },
            new Trade(){transactionTime = new DateTime(2018,8,15), amount = 1274.60M,closeRate=16.89M,rate = 974.50M },
            /*new Spots(){dateInput = new DateTime(2018,8,14), goldVal = 1281.10M,silverVal=16.97M,platiniumVal = 967.40M },
            new Spots(){dateInput = new DateTime(2018,8,11), goldVal = 1288.30M,silverVal=17.09M,platiniumVal = 974.90M },
            new Spots(){dateInput = new DateTime(2018,8,10), goldVal = 1278.90M,silverVal=17.08M,platiniumVal = 989.70M },
            new Spots(){dateInput = new DateTime(2018,8,9), goldVal = 1267.95M,silverVal=16.59M,platiniumVal = 985.90M },
            new Spots(){dateInput = new DateTime(2018,8,8), goldVal = 1261.45M,silverVal=16.39M,platiniumVal = 976.10M },
            new Spots(){dateInput = new DateTime(2018,8,7), goldVal = 1257.55M,silverVal=16.13M,platiniumVal = 974.50M },
            new Spots(){dateInput = new DateTime(2018,8,4), goldVal = 1269.30M,silverVal=16.70M,platiniumVal = 971.60M },
            new Spots(){dateInput = new DateTime(2018,8,3), goldVal = 1261.80M,silverVal=16.47M,platiniumVal = 969.00M },
            new Spots(){dateInput = new DateTime(2018,8,2), goldVal = 1266.65M,silverVal=16.67M,platiniumVal = 964.60M },
            new Spots(){dateInput = new DateTime(2018,8,1), goldVal = 1267.05M,silverVal=16.74M,platiniumVal = 953.80M },
            new Spots(){dateInput = new DateTime(2018,7,31), goldVal = 1266.35M,silverVal=16.76M,platiniumVal = 949.50M },
            new Spots(){dateInput = new DateTime(2018,7,28), goldVal = 1259.60M,silverVal=16.56M,platiniumVal = 940.70M },
            new Spots(){dateInput = new DateTime(2018,7,27), goldVal = 1262.05M,silverVal=16.79M,platiniumVal = 936.60M },
            new Spots(){dateInput = new DateTime(2018,7,26), goldVal = 1245.40M,silverVal=16.37M,platiniumVal = 926.40M },
            new Spots(){dateInput = new DateTime(2018,7,25), goldVal = 1252.05M,silverVal=16.31M,platiniumVal = 922.70M },
            new Spots(){dateInput = new DateTime(2018,7,26), goldVal = 1255.55M,silverVal=16.50M,platiniumVal = 931.80M },
            new Spots(){dateInput = new DateTime(2018,7,25), goldVal = 1247.25M,silverVal=16.43M,platiniumVal = 932.30M },
            new Spots(){dateInput = new DateTime(2018,7,20), goldVal = 1236.55M,silverVal=16.18M,platiniumVal = 937.40M },
            new Spots(){dateInput = new DateTime(2018,7,19), goldVal = 1239.85M,silverVal=16.23M,platiniumVal = 932.30M },
            new Spots(){dateInput = new DateTime(2018,7,28), goldVal = 1237.10M,silverVal=16.17M,platiniumVal = 924.20M },
            new Spots(){dateInput = new DateTime(2018,7,17), goldVal = 1229.85M,silverVal=16.07M,platiniumVal = 930.300M },
            new Spots(){dateInput = new DateTime(2018,7,14), goldVal = 1218.95M,silverVal=15.71M,platiniumVal = 930.30M },*/
                /*    public int Id { get; set; }
            public DateTime transactionTime { get; set; }

            public decimal amount { get; set; }
            public decimal closeRate { get; set; }
            public decimal rate { get; set; }*/
            };
        }
        static IEnumerable<Ticker> GetPreconfiguredTickers()
        {
            return new List<Ticker>()
            {
            new Ticker(){low = 1,high = 2,vwap = 3,volume = 4,last = 5,ask = 6,bid = 7 },
             new Ticker(){low = 11,high = 12,vwap = 13,volume = 41,last = 15,ask = 6,bid = 17 },
            };
        }
        static IEnumerable<ExchangeRate> GetPreconfiguredExchangeRates()
        {
            return new List<ExchangeRate>()
            {
                new ExchangeRate(){dateInput = System.DateTime.Now, PLN = 1,EUR=2,GBP = 3 },
                new ExchangeRate(){dateInput = System.DateTime.Now, PLN = 11,EUR=12,GBP = 33 },
            };
            /*
        public int Id { get; set; }
        public DateTime dateInput { get; set; }

        public Double PLN { get; set; }
        public Double EUR { get; set; }
        public Double GBP { get; set; }*/
        }
    }

}

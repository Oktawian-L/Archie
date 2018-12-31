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
            new Spots(){dateInput = System.DateTime.Now, goldVal = 1,silverVal=2,platiniumVal = 3 },
            new Spots{dateInput = System.DateTime.Now, goldVal = 11,silverVal=12,platiniumVal = 33 },
            };
        }
        static IEnumerable<Trade> GetPreconfiguredTrades()
        {
            return new List<Trade>()
            {
                new Trade(){transactionTime = System.DateTime.Now, amount = 1,closeRate=2,rate= 3 },
                new Trade(){transactionTime = System.DateTime.Now, amount = 11,closeRate=12,rate = 33 },
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

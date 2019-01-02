using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archie.Models;

namespace Archie.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SyrakuzaContext context)
        {
            context.Database.EnsureCreated();

            if (context.Spots.Any())
            {
                return;   // DB has been seeded
            }
            if (context.Trades.Any())
            {
                return;   // DB has been seeded
            }
            if (context.Tickers.Any())
            {
                return;   // DB has been seeded
            }
                
            if (context.Tickers.Any())
            {
                return;   // DB has been seeded
            }
            var spots = new Spots[]
            {
            new Spots{dateInput=System.DateTime.Now,goldVal=10,silverVal=11}
            };
            foreach (Spots s in spots)
            {
                context.Spots.Add(s);
            }
            var trades = new Trade[]
            {
            new Trade{transactionTime=System.DateTime.Now,rate=10,closeRate=18, amount=100}
            };
            foreach (Trade t in trades)
            {
                context.Trades.Add(t);
            }
            var tickers = new Ticker[]
{
            new Ticker{low=10, high=10, vwap=200 ,volume=10,last=18, ask=10, bid=100}
};
            foreach (Ticker t in tickers)
            {
                context.Tickers.Add(t);
            }
            context.SaveChanges();

         
            context.SaveChanges();
        }
    }
}

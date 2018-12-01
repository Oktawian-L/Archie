using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archie.Models
{
    public class TickerStorage
    {
        public int Id { get; set; }

        public decimal low { get; set; }
        public decimal high { get; set; }
        public decimal vwap { get; set; }
        public decimal volume { get; set; }
        public decimal last { get; set; }
        public decimal ask { get; set; }
        public decimal bid { get; set; }
    }
}

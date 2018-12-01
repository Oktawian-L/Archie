using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archie.Models
{
    public class Trade
    {
        public int Id { get; set; }
        public DateTime transactionTime { get; set; }

        public decimal amount { get; set; }
        public decimal closeRate { get; set; }
        public decimal rate { get; set; }
    }
}

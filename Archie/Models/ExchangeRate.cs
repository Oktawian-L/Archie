using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archie.Models
{
    public class ExchangeRate
    {

        public int Id { get; set; }
        public DateTime dateInput { get; set; }

        public double PLN { get; set; }
        public double EUR { get; set; }
        public double GBP { get; set; }
    }
}

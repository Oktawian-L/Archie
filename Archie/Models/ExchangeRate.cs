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

        public Double PLN { get; set; }
        public Double EUR { get; set; }
        public Double GBP { get; set; }
    }
}

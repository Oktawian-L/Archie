using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archie.Models
{
    public class Spots
    {
        public int Id { get; set; }
        public DateTime dateInput { get; set; }

        public decimal goldVal { get; set; }
        public decimal silverVal { get; set; }
        public decimal platiniumVal { get; set; }
    }
}

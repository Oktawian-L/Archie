using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldAPI
{
    public class SpotAPI
    {
  
        public int Id { get; set; }
        public DateTime dateInput { get; set; }

        public decimal goldVal { get; set; }
        public decimal silverVal { get; set; }
        public decimal platiniumVal { get; set; }

        //constructor
        /*public SpotAPI(JObject jObject)
        {
          
            
               
                dateInput = (DateTime)jObject["date"];
                goldVal = (decimal)jObject["gold"];
                silverVal = (decimal)jObject["silver"];
                platiniumVal = (decimal)jObject["platinum"];
            
        }*/

    }
    
}

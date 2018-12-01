namespace SpotAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExchangeRates
    {
        public int Id { get; set; }

        public double EUR { get; set; }

        public double GBP { get; set; }

        public double PLN { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime dateInput { get; set; }
    }
}

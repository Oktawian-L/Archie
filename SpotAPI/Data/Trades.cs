namespace SpotAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trades
    {
        public int Id { get; set; }

        public decimal amount { get; set; }

        public decimal closeRate { get; set; }

        public decimal rate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime transactionTime { get; set; }
    }
}

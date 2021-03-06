namespace KryptoAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SpotsAPI")]
    public partial class SpotsAPI
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime dateInput { get; set; }

        public decimal goldVal { get; set; }

        public decimal platiniumVal { get; set; }

        public decimal silverVal { get; set; }
    }
}

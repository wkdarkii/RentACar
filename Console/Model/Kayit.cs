namespace Console.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kayit")]
    public partial class Kayit
    {
        public int kayitID { get; set; }

        public int? musteriID { get; set; }

        public int? odaID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? girisTarih { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? cikisTarih { get; set; }

        [Column(TypeName = "money")]
        public decimal? fiyat { get; set; }

        public virtual Musteri Musteri { get; set; }

        public virtual Oda Oda { get; set; }
    }
}

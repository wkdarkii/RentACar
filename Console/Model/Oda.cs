namespace Console.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Oda")]
    public partial class Oda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Oda()
        {
            Kayit = new HashSet<Kayit>();
        }

        public int odaID { get; set; }

        public int? odaTurID { get; set; }

        public int? odaNo { get; set; }

        public int? otelID { get; set; }

        [Column(TypeName = "money")]
        public decimal? gunlukFiyat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kayit> Kayit { get; set; }

        public virtual OdaTur OdaTur { get; set; }

        public virtual Otel Otel { get; set; }
    }
}

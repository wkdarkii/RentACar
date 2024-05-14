namespace Entitys.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        public int kullaniciID { get; set; }

        public int? rolID { get; set; }

        [StringLength(50)]
        public string ad { get; set; }

        [StringLength(50)]
        public string soyad { get; set; }

        [StringLength(50)]
        public string kullaniciAd { get; set; }

        [StringLength(50)]
        public string sifre { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string telefon { get; set; }

        public virtual Rol? Rol { get; set; }
    }
}

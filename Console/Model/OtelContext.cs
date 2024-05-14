using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Console.Model
{
    public partial class OtelContext : DbContext
    {
        public OtelContext()
            : base("name=OtelContext")
        {
        }

        public virtual DbSet<Kayit> Kayit { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<Oda> Oda { get; set; }
        public virtual DbSet<OdaTur> OdaTur { get; set; }
        public virtual DbSet<Otel> Otel { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kayit>()
                .Property(e => e.fiyat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Oda>()
                .Property(e => e.gunlukFiyat)
                .HasPrecision(19, 4);
        }
    }
}

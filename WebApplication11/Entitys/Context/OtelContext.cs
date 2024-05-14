using Entitys.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WebApplication11.Entitys.Entity;

namespace WebApplication11.Entitys.Context
{
    public partial class OtelContext : DbContext
    {
        public OtelContext(DbContextOptions<OtelContext> options) : base(options) { }
        public virtual DbSet<Kayit> Kayit { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<OdaTur> OdaTur { get; set; }
        public virtual DbSet<Otel> Otel { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Oda> Oda { get; set; }
        public virtual DbSet<Rezervasyon> Rezervasyon { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=GALAXYDESTROYER;initial catalog=OtelDB;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Kayit>()
                .Property(e => e.fiyat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Oda>()
                .Property(e => e.gunlukFiyat)
                .HasPrecision(19, 4);
        }
    }
}

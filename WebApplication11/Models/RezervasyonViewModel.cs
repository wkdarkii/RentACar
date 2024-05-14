using Entitys.Entity;

namespace WebApplication11.Models
{
    public class RezervasyonViewModel
    {
        public int odaID { get; set; }
        public string MusteriAd { get; set; }
        public string MusteriSoyad { get; set; }
        public string Telefon { get; set; }
        public DateTime girisTarih { get; set; }
        public DateTime cikisTarih { get; set; }
        public Oda? Oda { get; set; }

	}
}

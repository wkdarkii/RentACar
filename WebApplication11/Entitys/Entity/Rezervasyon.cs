using Entitys.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication11.Entitys.Entity
{
	[Table("Rezervasyon")]
	public class Rezervasyon
	{
		public int rezervasyonID { get; set; }
		public int kullaniciID { get; set; }
		public int odaID { get; set; }
		public DateTime girisTarihi { get; set; }
		public DateTime cikisTarihi { get; set; }
		public int kisiSayisi { get; set; }

		
		public virtual Kullanici Kullanici { get; set; }
		public virtual Oda Oda { get; set; }
	}
}

using Entitys.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Entitys.Context;
using WebApplication11.Session;

namespace WebApplication11.Areas.Admin.Controllers
{
    [ServiceFilter(typeof(SessionAuthorizationFilter))]
    [Area("Admin")]
    public class AdminKayitMusteriController : Controller
    {
        private OtelContext _otelContext { get; set; }

        public AdminKayitMusteriController()
        {
            _otelContext = new OtelContext(new DbContextOptions<OtelContext>());
        }
        public IActionResult Index()
		{
			var Rezervasyonlar =_otelContext.Kayit.ToList();

            var Rezervasyon = Rezervasyonlar.Select(x =>new Kayit
            {
                 cikisTarih=x.cikisTarih,
                 musteriID=x.musteriID,
                 odaID=x.odaID,
                 girisTarih=x.girisTarih,
                 fiyat = x.fiyat
                 
            });

			return View(Rezervasyon);
		}
	}
}

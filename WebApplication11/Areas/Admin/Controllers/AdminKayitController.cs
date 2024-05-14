using Entitys.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Entitys.Context;
using WebApplication11.Session;

namespace WebApplication11.Areas.Admin.Controllers
{
    [ServiceFilter(typeof(SessionAuthorizationFilter))]
    [Area("Admin")]
    public class AdminKayitController : Controller
    {
        private OtelContext _otelContext { get; set; }

        public AdminKayitController()
        {
            _otelContext = new OtelContext(new DbContextOptions<OtelContext>());
        }
        public IActionResult Kayit()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Kayit(Kullanici k)
        {
            var kullanici = new Kullanici
            {

                ad = k.ad,
                email = k.email,
                kullaniciAd = k.kullaniciAd,
                rolID = k.rolID,
                soyad = k.soyad,
                telefon = k.telefon,
                sifre = k.sifre

            };

            await _otelContext.Kullanici.AddAsync(kullanici);

            await _otelContext.SaveChangesAsync();
            return View();
        }
    }
}

using Entitys.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Entitys.Context;
using WebApplication11.Session;

namespace WebApplication11.Areas.Admin.Controllers
{
    [ServiceFilter(typeof(SessionAuthorizationFilter))]
    [Area("Admin")]
    public class AdminKullaniciController : Controller
    {
        private OtelContext _otelContext { get; set; }
        public AdminKullaniciController()
        {
            _otelContext = new OtelContext(new DbContextOptions<OtelContext>());
        }

        public IActionResult Index()
        {
            var model = _otelContext.Kullanici.ToList();
            return View(model);
        }

        public IActionResult Delete(int UserID)
        {
            var user = _otelContext.Kullanici.FirstOrDefault(x=> x.kullaniciID == UserID);

            _otelContext.Kullanici.Remove(user);
            _otelContext.SaveChanges();

            return RedirectToAction("Index" ,"AdminKullanici");
        }

        public ActionResult Edit(int UserID)
        {
            var user = _otelContext.Kullanici.FirstOrDefault(x => x.kullaniciID == UserID);


            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Kullanici k)
        {
            var kullanici = await _otelContext.Kullanici.FindAsync(k.kullaniciID);

            if (kullanici == null)
            {
                return NotFound();
            }
            kullanici.ad = k.ad;
            kullanici.email = k.email;
            kullanici.kullaniciAd = k.kullaniciAd;
            kullanici.sifre = k.sifre;
            kullanici.telefon = k.telefon;
            kullanici.soyad = k.soyad;
            await _otelContext.SaveChangesAsync(); 

            return RedirectToAction("Index", "AdminKullanici");
        }
    }
}

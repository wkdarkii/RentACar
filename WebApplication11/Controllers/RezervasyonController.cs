using Entitys.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Entitys.Context;
using WebApplication11.Models;

namespace WebApplication11.Controllers;

public class RezervasyonController : Controller
{
    private OtelContext _otelContext { get; set; }
    public RezervasyonController()
    {
        _otelContext = new OtelContext(new DbContextOptions<OtelContext>());
    }

    public IActionResult Index()
    {
        //İlanlar burada olacak
        //Databaseden veri çekilip alttaki gibi gösterilecek
        //Take(6) altı adet kayıt getir 
        return View();
    }
    public IActionResult Rezervasyon(int id)
    {
        var oda = _otelContext.Oda.Include(o => o.OdaTur).Where(o => o.odaID == id).FirstOrDefault();
        if (oda == null)
        {
            return RedirectToAction("Index", "Home");
        }

        var model = new RezervasyonViewModel
        {
            Oda = oda
        };

        return View(model);

    }
    [HttpPost]
    public IActionResult Rezervasyon(RezervasyonViewModel model)
    {
        var musteri = _otelContext.Musteri.Where(m => m.telefon == model.Telefon).SingleOrDefault();
        if (musteri == null)
        {
            musteri = new Musteri
            {
                telefon = model.Telefon,
                ad = model.MusteriAd,
                soyad = model.MusteriSoyad
            };
            var result = _otelContext.Musteri.Add(musteri);
            _otelContext.SaveChanges(); // Değişiklikleri kaydedin
            musteri = _otelContext.Musteri.Where(m => m.telefon == model.Telefon).SingleOrDefault();

        }
        var oda = _otelContext.Oda.Where(o=> o.odaID == model.odaID).SingleOrDefault();
        var kayit = new Kayit
        {
            musteriID = musteri.musteriID,
            odaID = model.odaID,
            girisTarih = model.girisTarih,
            cikisTarih = model.cikisTarih,
            fiyat = (model.cikisTarih.Day - model.girisTarih.Day) * oda.gunlukFiyat,
        };
        _otelContext.Kayit.Add(kayit);
        _otelContext.SaveChanges();
        return RedirectToAction("Rezervasyonkayit", "Rezervasyon");

    }


    public IActionResult Edit(int id)
    {
        var kayit = _otelContext.Kayit.Find(id);
        if (kayit == null)
        {
            return NotFound();
        }
        return View(kayit);
    }

    [HttpPost]
    public IActionResult Edit(int id, Kayit kayit)
    {
        if (id != kayit.kayitID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _otelContext.Update(kayit);
            _otelContext.SaveChanges();
            return RedirectToAction(nameof(Rezervasyonkayit));
        }
        return View(kayit);
    }

    public IActionResult Delete(int id)
    {
        var kayit = _otelContext.Kayit.Find(id);
        if (kayit == null)
        {
            return NotFound();
        }

        return View(kayit);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var kayit = _otelContext.Kayit.Find(id);
        _otelContext.Kayit.Remove(kayit);
        _otelContext.SaveChanges();
        return RedirectToAction(nameof(Rezervasyonkayit));
    }


    public IActionResult Rezervasyonkayit()
    {
        int userId = (int)HttpContext.Session.GetInt32("UserId").Value;

        var kayit = _otelContext.Kayit.Where(x=> x.musteriID == userId).ToList();

        var model = kayit.Select(x => new Kayit
        {
            cikisTarih=x.cikisTarih,
            girisTarih=x.girisTarih,
            fiyat=x.fiyat,
            
        });

        return View(kayit);

	}
}

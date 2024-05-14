using Entitys.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Entitys.Context;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class AccountController : Controller
    {
        private OtelContext _otelContext { get; set; }

        public AccountController()
        {
            _otelContext = new OtelContext(new DbContextOptions<OtelContext>());
        }

        public IActionResult Login()
        {
            var model = new Kullanici();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(Kullanici kullanici)
        {
            var user = _otelContext.Kullanici.Where(u => u.kullaniciAd == kullanici.kullaniciAd && u.sifre == kullanici.sifre).FirstOrDefault();
            
            if (user != null)
            {

				if (user.rolID==1)
				{
					HttpContext.Session.SetInt32("UserId", user.kullaniciID);

					return RedirectToAction("Index", "AdminHome", new { area = "Admin" });
				}
                // Set session variables
                else
				{
					HttpContext.Session.SetInt32("UserId", user.kullaniciID);

					return RedirectToAction("Index", "Home");

				}

                // Redirect to the home page
            }

            
            var musteri = _otelContext.Musteri.FirstOrDefault(m => m.email == kullanici.kullaniciAd && m.sifre == kullanici.sifre);
            if (musteri != null)
            {
                // Set session variables
                HttpContext.Session.SetInt32("UserId", musteri.musteriID);
                // Redirect to the home page
                return RedirectToAction("main", "OtelMain");
            }
            // If authentication fails, you might want to display an error message or redirect to a login page
            ViewBag.Message = "Invalid email or password";
            return View();
                    }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clears all items from the session
            return RedirectToAction("Index", "Home"); // Redirect to the home page after logout
        }


        public IActionResult Register()
        {
            var model = new Musteri();
            return View(model);
        }

        [HttpPost]
        public IActionResult Register(Musteri musteri)
        {
            try
            {
                _otelContext.Musteri.Add(musteri);
                var result = _otelContext.SaveChanges();

                if (result != 0) 
                { 
                    RedirectToAction("Index", "Home"); 
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Hata Mesajı: " + ex.Message;
            }
            ViewBag.Message = "Kullanıcı Adı veya Şifre Hatalı";
            return View(musteri);
        }
    }
}

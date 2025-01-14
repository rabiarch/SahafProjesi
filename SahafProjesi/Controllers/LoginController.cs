using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using SahafProjesi.Data;
using SahafProjesi.Models.ViewModels;
using SahafProjesi.Utilities;

namespace SahafProjesi.Controllers
{
    public class LoginController : Controller
    {
        private readonly SahafDbContext _context;

        public LoginController(SahafDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(Login_VM model)
        {
            if (ModelState.IsValid) 
            {
                string sifre = Hasher.Md5Hasher(model.Sifre);
                //return Content(model.Sifre + " " + model.KullaniciAdi);
                var kullanici = _context.Kullanicilar.Where(x => x.KullaniciAdi == model.KullaniciAdi && x.Sifre == sifre).SingleOrDefault();

                if (kullanici == null)
                {
                    ModelState.AddModelError("Hata", "Kullanıcı adı veya şifre hatalı!");
                    return View();
                }

                HttpContext.Session.SetInt32("kullaniciId", kullanici.KullaniciID);

                //return Content(HttpContext.Session.GetInt32("kullaniciId").ToString());
                return RedirectToAction("Index", "Kullanici");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("kullaniciId");
            return RedirectToAction("Index","Login");
        }

    }
}

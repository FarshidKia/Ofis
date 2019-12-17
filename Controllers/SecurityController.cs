using Ofis_ISE309.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Ofis_ISE309.Controllers
{
    
    public class SecurityController : Controller
    {
        // GET: Security
        OfisEntities4 db = new OfisEntities4();
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Kullanici kullanici)
        {
            var kullaniciInDb = db.Kullanici.FirstOrDefault(x => x.Ad == kullanici.Ad && x.Sifre == kullanici.Sifre);
            if (kullaniciInDb!=null)
            {
                FormsAuthentication.SetAuthCookie(kullaniciInDb.Ad, false);
                return RedirectToAction("Index","Departman");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı Adı Veya Şifre Girdiniz!";
                return View();
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
using Ofis_ISE309.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ofis_ISE309.Controllers
{
    public class DepartmanController : Controller
    {
        OfisEntities1 db = new OfisEntities1();
        // GET: Departman
        public ActionResult Index()
        {
            var model = db.Departman.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            return View("DepartmanForm");

        }
        [HttpPost]
        public ActionResult Yeni(Departman departman)
        {
            db.Departman.Add(departman);
            db.SaveChanges();
            return RedirectToAction("Index", "Departman");

        }
        public ActionResult Guncelle(int id)
        {
            var model = db.Departman.Find(id);
            if (model == null)
                return HttpNotFound();
            return View("DepartmanForm",model);
        }
        public ActionResult Sil(int id)
        {
            var SilinecekDepartman = db.Departman.Find(id);
            if (SilinecekDepartman == null)
                return HttpNotFound();
            db.Departman.Remove(SilinecekDepartman);
            //Entity validation hata tesbiti
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
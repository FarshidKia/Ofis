using Ofis_ISE309.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.WebPages.Html;

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
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Departman departman)
        {
            if (ModelState.IsValid)
            {
                db.Departman.Add(departman);
                db.SaveChanges();
                return RedirectToAction("Index", "Departman");
            }
            return View(departman);
           

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

using Ofis_ISE309.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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
        public ActionResult Kaydet(Departman departman)
        {
            if (departman.Id == 0)
            {
                db.Departman.Add(departman);
            }
            else
            {
                var GuncellenecekDepartman = db.Departman.Find(departman.Id);
                if (GuncellenecekDepartman == null)
                {
                    return HttpNotFound();
                }
                GuncellenecekDepartman.Ad = departman.Ad;
            }
            //db.Departman.Add(departman);

            try {
                db.SaveChanges();
             
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    // Get entry

                    DbEntityEntry entry = item.Entry;
                    string entityTypeName = entry.Entity.GetType().Name;

                    // Display or log error messages

                    foreach (DbValidationError subItem in item.ValidationErrors)
                    {
                        string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                 subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                        Console.WriteLine(message);
                    }
                }
            }
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
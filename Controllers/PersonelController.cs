using Ofis_ISE309.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Configuration;
using Ofis_ISE309.ViewModels;

namespace Ofis_ISE309.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        OfisEntities2 db = new OfisEntities2();
        public ActionResult Index()
        {
            var model = db.Personel.ToList();
            return View(model);
        }
        public ActionResult Yeni()

        {
            var model = new PersonelFormViewModel()
            {
                departmanlar = db.Departman.ToList(),
                Personel=new Personel()
            };
      
        
            return View("PersonelForm",model);
        }
        [ValidateAntiForgeryToken]
        public ActionResult kaydet(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                var model = new PersonelFormViewModel()
                {
                    departmanlar = db.Departman.ToList(),
                    Personel=personel
                };
                return View("PersonelForm",model);
            }
            if (personel.Id == 0) //ekleme işlemi
            {
                db.Personel.Add(personel);
            }
            else //Guncelle
            {
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Guncelle(int id)
        {
            var model = new PersonelFormViewModel()
            {
                departmanlar = db.Departman.ToList(),
                Personel = db.Personel.Find(id)
            };

            return View("PersonelForm",model);
        }
        public ActionResult Sil(int id)
        {
            var SilinecekPersonel = db.Personel.Find(id);
            if (SilinecekPersonel == null)
            {
                return HttpNotFound();
            }
            db.Personel.Remove(SilinecekPersonel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
    
}
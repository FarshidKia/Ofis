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
        public ActionResult Yeni(String DepartmanAdi)
        {
            var Departman = new Departman();
            Departman.Ad = DepartmanAdi;
            db.Departman.Add(Departman);
            db.SaveChanges();
            return View();

        }
    }
}
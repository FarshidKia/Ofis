using Ofis_ISE309.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ofis_ISE309.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        OfisEntities1 db = new OfisEntities1();
        public ActionResult Index()
        {
            var model = db.Personel.ToList();
            return View(model);
        }
    }
}
using BarSzybkiejObsługiMVC.DAL;
using BarSzybkiejObsługiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BarSzybkiejObsługiMVC.Controllers
{
    public class ProduktyController : Controller
    {
        private BarContext db = new BarContext();
        // GET: Produkty
        public ActionResult Szczegoly(int id)
        {
            var produktSzczegoly = db.Produkty.SingleOrDefault(p => p.ProduktId.Equals(id));

            return View(produktSzczegoly);
        }
    }
}
using BarSzybkiejObsługiMVC.DAL;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BarSzybkiejObsługiMVC.Controllers
{
    public class HomeController : Controller
    {

        private BarContext db = new BarContext();

        public ActionResult Index()
        {
            var polecane = db.Produkty.Where(p => !p.Ukryty && p.Polecany)
                .OrderBy(p => Guid.NewGuid()).Take(3).ToList();

            return View(polecane);
        }
    }
}
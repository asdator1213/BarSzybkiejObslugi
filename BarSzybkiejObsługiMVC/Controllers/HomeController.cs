using BarSzybkiejObsługiMVC.DAL;
using BarSzybkiejObsługiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BarSzybkiejObsługiMVC.Controllers
{
    public class HomeController : Controller
    {

        private BarContext db = new BarContext();

        // GET: Home
        public ActionResult Index()
        {
            
            var polecane = db.Produkty.Where(p => !p.Ukryty && p.Polecany)
                .OrderBy(p => Guid.NewGuid()).Take(3).ToList();
            

            return View(polecane);
        }
    }
}
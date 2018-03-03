using BarSzybkiejObsługiMVC.DAL;
using System.Linq;
using System.Web.Mvc;

namespace BarSzybkiejObsługiMVC.Controllers
{
    public class KategorieController : Controller
    {
        private BarContext db = new BarContext();

        public ActionResult ListaProduktow(string kategoria)
        {
            var produktyKategorii = db.Produkty
                .Where(p=>p.Ukryty!=true 
                && p.Kategoria.NazwaKategorii == kategoria).ToList();

            return View(produktyKategorii);
        }
    }
}
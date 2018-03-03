using BarSzybkiejObsługiMVC.DAL;
using BarSzybkiejObsługiMVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace BarSzybkiejObsługiMVC.Controllers
{
    public class ProduktyController : Controller
    {
        private BarContext db = new BarContext();
        // GET: Produkty
        public ActionResult Szczegoly(int id)
        {
            var produktSzczegoly = db.Produkty.Find(id);
            return View(produktSzczegoly);
        }

        [Authorize(Roles ="Pracownik")]
        public ActionResult Edytuj(int id)
        {
            var produkt = db.Produkty.Find(id);
            return View(produkt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edytuj(Produkt prod)
        {
            if(ModelState.IsValid)
            {
                var produkt = db.Produkty.Find(prod.ProduktId);

                produkt.NazwaProduktu = prod.NazwaProduktu;
                produkt.CzasPrzygotowania = prod.CzasPrzygotowania;
                produkt.Cena = prod.Cena;
                produkt.Opisy.Opis = prod.Opisy.Opis;

                db.SaveChanges();
            }
            return RedirectToAction("Edytuj", new { id = prod.ProduktId });
        }

        [Authorize(Roles = "Pracownik")]
        public ActionResult Ukryj(int id)
        {
            var produkt = db.Produkty.Find(id);
            produkt.Ukryty = true;
            db.SaveChanges();
            return RedirectToAction("Szczegoly", new { id = produkt.ProduktId });
        }

        [Authorize(Roles = "Pracownik")]
        public ActionResult Pokaz(int id)
        {
            var produkt = db.Produkty.Find(id);
            produkt.Ukryty = false;
            db.SaveChanges();
            return RedirectToAction("Szczegoly", new { id = produkt.ProduktId });
        }

        public ActionResult Wszystko()
        {
            return View(db.Produkty.ToList());
        }
    }
}
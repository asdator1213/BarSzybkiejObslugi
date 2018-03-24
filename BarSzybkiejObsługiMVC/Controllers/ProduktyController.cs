using BarSzybkiejObsługiMVC.DAL;
using BarSzybkiejObsługiMVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BarSzybkiejObsługiMVC.Controllers
{
    public class ProduktyController : Controller
    {
        private BarContext db = new BarContext();

        public ActionResult Szczegoly(int id)
        {
            var produktSzczegoly = db.Produkty.Find(id);
            return View(produktSzczegoly);
        }

        [Authorize(Roles ="Pracownik")]
        public ActionResult Edytuj(int id)
        {
            KategorieDropDown();
            var produkt = db.Produkty.Find(id);
            return View(produkt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Pracownik")]
        public ActionResult Edytuj(Produkt prod)
        {
            if(ModelState.IsValid)
            {
                var produkt = db.Produkty.Find(prod.ProduktId);

                produkt.NazwaProduktu = prod.NazwaProduktu;
                produkt.CzasPrzygotowania = prod.CzasPrzygotowania;
                produkt.Cena = prod.Cena;
                produkt.Opisy.Opis = prod.Opisy.Opis;
                produkt.Opisy.OpisKrotki = prod.Opisy.OpisKrotki;
                produkt.KategoriaId = prod.KategoriaId;

                db.SaveChanges();
            }
            return RedirectToAction("Edytuj", new { id = prod.ProduktId });
        }

        [Authorize(Roles = "Pracownik")]
        public ActionResult Ukryj(int id, string url)
        {
            var produkt = db.Produkty.Find(id);
            produkt.Ukryty = true;
            db.SaveChanges();
            return RedirectToAction(url, new { id = produkt.ProduktId });
        }

        [Authorize(Roles = "Pracownik")]
        public ActionResult Pokaz(int id, string url)
        {
            var produkt = db.Produkty.Find(id);
            produkt.Ukryty = false;
            db.SaveChanges();
            return RedirectToAction(url, new { id = produkt.ProduktId });
        }

        private void KategorieDropDown()
        {
            var kategorie = db.Kategorie.ToList().Select(x => new SelectListItem
            {
                Text = x.NazwaKategorii,
                Value = x.KategoriaId.ToString()
            });

            ViewBag.Kategorie = kategorie;
        }

        [Authorize(Roles ="Pracownik")]
        public ActionResult Wszystko()
        {
            return View(db.Produkty.ToList());
        }

        [Authorize(Roles = "Pracownik")]
        public ActionResult Dodaj()
        {
            KategorieDropDown();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Pracownik")]
        public ActionResult Dodaj(Produkt prod)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    db.Produkty.Add(prod);
                    db.SaveChanges();
                }
                catch(Exception)
                {
                    return View(prod);
                }
                return RedirectToAction("Wszystko");
            }
            return View(prod);
        }

        [Authorize(Roles = "Pracownik")]
        public ActionResult Polecany(int id, string url)
        {
            var produkt = db.Produkty.Find(id);
            produkt.Polecany = true;
            db.SaveChanges();
            return RedirectToAction(url, new { id = produkt.ProduktId });
        }

        [Authorize(Roles = "Pracownik")]
        public ActionResult Niepolecany(int id, string url)
        {
            var produkt = db.Produkty.Find(id);
            produkt.Polecany = false;
            db.SaveChanges();
            return RedirectToAction(url, new { id = produkt.ProduktId });
        }
    }
}
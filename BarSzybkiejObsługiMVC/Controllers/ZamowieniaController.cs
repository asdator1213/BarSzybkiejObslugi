using BarSzybkiejObsługiMVC.DAL;
using BarSzybkiejObsługiMVC.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BarSzybkiejObsługiMVC.Controllers
{
    public class ZamowieniaController : Controller
    {
        private BarContext db = new BarContext();

        //Authorize
        [Authorize(Roles = "Pracownik")]
        public ActionResult Index()
        {
            var zamowienia = db.Zamowienia.ToList();
            return View(zamowienia);
        }

        //Authorize
        [Authorize(Roles = "Pracownik")]
        public ActionResult Szczegoly(int id)
        {
            var zamowienie = db.Zamowienia
                .Include("PozycjeZamowienia").SingleOrDefault(p=>p.ZamowienieId==id);
            return View(zamowienie);
        }

        [Authorize(Roles ="Pracownik")]
        public ActionResult EdytujKlienta(int id)
        {
            var klient = db.Klienci.Find(id);
            return View(klient);
        }

        [Authorize(Roles = "Pracownik")]
        [HttpPost]
        public ActionResult EdytujKlienta([Bind(Include ="Id,Imie,Nazwisko,Telefon,Email")]Klient klient)
        {
            if(ModelState.IsValid)
            {
                db.Entry(klient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Szczegoly", new { id=klient.Id});
            }
            return View(klient);
        }

        [Authorize(Roles = "Pracownik")]
        [HttpPost]
        public ActionResult Zapisz([Bind(Include = "ZamowienieId,NaKiedy,Komentarz,StanZamowienia")]Zamowienie zam)
        {
            if (ModelState.IsValid)
            {
                var zamowienie = db.Zamowienia.Find(zam.ZamowienieId);

                zamowienie.NaKiedy = zam.NaKiedy;
                zamowienie.Komentarz = zam.Komentarz;
                zamowienie.StanZamowienia = zam.StanZamowienia;
                if(zamowienie.StanZamowienia == StanZamowienia.Zrealizowane)
                {
                    zamowienie.Platnosc = db.Platnosci.SingleOrDefault(p => p.Id == zamowienie.PlatnoscId);
                    zamowienie.Platnosc.DataPlatnosci = DateTime.Now;
                    zamowienie.Platnosc.CzyZaplacono = true;
                }
                
                db.SaveChanges();
            }
            return RedirectToAction("Szczegoly", new { id = zam.ZamowienieId });
        }
    }
}
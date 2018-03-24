using BarSzybkiejObsługiMVC.DAL;
using BarSzybkiejObsługiMVC.Infrastructure;
using BarSzybkiejObsługiMVC.Models;
using Microsoft.AspNet.Identity;
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
        public ActionResult Index(string orderCode)
        {
            var zamowienia = db.Zamowienia.ToList();
            if (!String.IsNullOrEmpty(orderCode))
            {
                zamowienia = zamowienia.Where(z=>z.KodZamowienia.Contains(orderCode)).ToList();
            }
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

                var powiadomienie = new PowiadomienieSms(db);
                powiadomienie.SprawdzStanZamowienia(ref zamowienie);
                
                db.SaveChanges();
            }
            return RedirectToAction("Szczegoly", new { id = zam.ZamowienieId });
        }

        [Authorize(Roles ="Pracownik")]
        public ActionResult Zaklep(int id)
        {
            var zamowienie = db.Zamowienia.Find(id);
            var userid = User.Identity.GetUserId();
            var username = db.Users.Find(userid).Name;
            zamowienie.PracownikImieNazwisko = username;
            zamowienie.PracownikId = userid;

            db.SaveChanges();

            return RedirectToAction("Szczegoly", new { id = zamowienie.ZamowienieId });
        }

        public ActionResult Porzuc(int id)
        {
            var zamowienie = db.Zamowienia.Find(id);
            zamowienie.PracownikId = null;
            zamowienie.PracownikImieNazwisko = null;

            db.SaveChanges();
            return RedirectToAction("Szczegoly", new { id = zamowienie.ZamowienieId });
        }
    }
}
using BarSzybkiejObsługiMVC.DAL;
using BarSzybkiejObsługiMVC.Infrastructure;
using BarSzybkiejObsługiMVC.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;


namespace BarSzybkiejObsługiMVC.Controllers
{
    public class KoszykController : Controller
    {
        private KoszykManager koszykManager;
        private ISessionManager sessionManager { get; set; }
        private BarContext db;

        public KoszykController()
        {
            db = new BarContext();
            sessionManager = new SessionManager();
            koszykManager = new KoszykManager(sessionManager, db);
        }

        public ActionResult Index()
        {
            var pozycjeKoszyka = koszykManager.PobierzKoszyk();
            var cenaCalkowita = koszykManager.PobierzWartoscKoszyka();

            KoszykViewModel koszykVM = new KoszykViewModel()
            {
                PozycjeKoszyka = pozycjeKoszyka,
                CenaCałkowita = cenaCalkowita
            };

            return View(koszykVM);
        }

        public ActionResult DodajDoKoszyka(int id)
        {
            koszykManager.DodajDoKoszyka(id);
            return RedirectToAction("Index");
        }

        public int PobierzIloscElementowKoszyka()
        {
            return koszykManager.PobierzIloscPozycjiKoszyka();
        }
        public ActionResult UsunZKoszyka(int produktId)
        {
            int iloscPozycji = koszykManager.UsunZKoszyka(produktId);
            int iloscPozycjiKoszyka = koszykManager.PobierzIloscPozycjiKoszyka();
            decimal wartoscKoszyka = koszykManager.PobierzWartoscKoszyka();

            var wynik = new KoszykUsuwanieVM
            {
                IdPozycjiUsuwanej = produktId,
                IloscPozycjiUsuwanej = iloscPozycji,
                KoszykIloscPozycji = iloscPozycjiKoszyka,
                KoszykCenaCalkowita = wartoscKoszyka
            };

            return Json(wynik);
        }

        public ActionResult ZlozZamowienie()
        {
            var zamowienie = new ZamowienieViewModel
            {
                PozycjeKoszyka = koszykManager.PobierzKoszyk(),
                WartoscZamowienia = koszykManager.PobierzWartoscKoszyka(),
            };
            zamowienie.CzasOczekiwania = zamowienie.PozycjeKoszyka
                .Max(x => x.Produkt.CzasPrzygotowania);

            DateTime dt = DateTime.Now;
            dt = dt.AddMinutes(zamowienie.CzasOczekiwania);
            zamowienie.NaKiedy = dt;

            return View(zamowienie);
        }


        [HttpPost]
        public ActionResult ZlozZamowienie(ZamowienieViewModel zamowienie)
        {
            if (ModelState.IsValid)
            {
                var noweZamowienie = koszykManager.UtworzZamowienie(zamowienie);
                //koszykManager.PustyKoszyk();

                return RedirectToAction("PotwierdzenieZamowienia", new { nrZamowienia = noweZamowienie.ZamowienieId });
            }

            return View(zamowienie);
        }

        public ActionResult PotwierdzenieZamowienia(int nrZamowienia)
        {
            var zamowienie = db.Zamowienia
                .SingleOrDefault(p => p.ZamowienieId == nrZamowienia);

            var zamowienieVM = new ZamowienieViewModel
            {
                ZamowienieId = zamowienie.ZamowienieId,
                Imie = zamowienie.Klient.Imie,
                Nazwisko = zamowienie.Klient.Nazwisko,
                Telefon = zamowienie.Klient.Telefon,
                Email = zamowienie.Klient.Email,
                PozycjeKoszyka = koszykManager.PobierzKoszyk(),
                WartoscZamowienia = zamowienie.Platnosc.Kwota,
                DataDodania = zamowienie.DataDodania,
                Komentarz = zamowienie.Komentarz,
                StanZamowienia = zamowienie.StanZamowienia,
                NaKiedy = zamowienie.NaKiedy,
                TypPlatnosci = zamowienie.Platnosc.TypPlatnosci,
                KodZamowienia = zamowienie.KodZamowienia
               
            };

            //koszykManager.PustyKoszyk();

            zamowienieVM.CzasOczekiwania = zamowienieVM.PozycjeKoszyka
                .Max(x => x.Produkt.CzasPrzygotowania);

            var message = $"Zamówienie zostało przyjęte. Kwota do zapłaty: " +
                $"{zamowienie.Platnosc.Kwota}zł, Termin odbioru: {zamowienie.NaKiedy}," +
                $" Kod zamówienia: {zamowienie.KodZamowienia}";

            //Smsing.Sender(message, zamowienie.Klient.Telefon);

            return View(zamowienieVM);
        }

        

    }
}
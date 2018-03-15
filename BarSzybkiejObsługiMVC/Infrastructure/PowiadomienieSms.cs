using BarSzybkiejObsługiMVC.DAL;
using BarSzybkiejObsługiMVC.Models;
using BarSzybkiejObsługiMVC.Utility;
using System;
using System.Linq;

namespace BarSzybkiejObsługiMVC.Infrastructure
{
    public class PowiadomienieSms
    {
        private BarContext db;

        public PowiadomienieSms(BarContext db)
        {
            this.db = db;
        }

        public void Przyjete(Zamowienie zamowienie)
        {
            var message = $"Zamówienie zostało przyjęte. Kwota do zapłaty: " +
                $"{zamowienie.Platnosc.Kwota}zł, Termin odbioru: {zamowienie.NaKiedy}," +
                $" Kod zamówienia: {zamowienie.KodZamowienia}";

            Smsing.Sender(message, zamowienie.Klient.Telefon);
        }

        public void DoOdbioru(Zamowienie zamowienie)
        {
            string message = $"Twoje zamówienie jest gotowe do odbioru! Kod zamówienia: {zamowienie.KodZamowienia}" +
                        $", kwota: {zamowienie.Platnosc.Kwota}.";
            Smsing.Sender(message, zamowienie.Klient.Telefon);
        }

        public void Oczekuje(Zamowienie zamowienie)
        {
            string message = $"Twoje zamówienie oczekuje na odbiór! W przypadku nieodebrania go w ciągu godziny, zamówienie zostanie anulowane. " +
                $"Kod zamówienia: {zamowienie.KodZamowienia}, kwota: {zamowienie.Platnosc.Kwota} zł.";
            Smsing.Sender(message, zamowienie.Klient.Telefon);
        }

        public void Zrealizowane(Zamowienie zamowienie)
        {
            zamowienie.Platnosc = db.Platnosci.SingleOrDefault(p => p.Id == zamowienie.PlatnoscId);
            zamowienie.Platnosc.DataPlatnosci = DateTime.Now;
            zamowienie.Platnosc.CzyZaplacono = true;
        }

        public void SprawdzStanZamowienia(ref Zamowienie zamowienie)
        {
            switch(zamowienie.StanZamowienia)
            {
                case StanZamowienia.Oczekujące:
                    DoOdbioru(zamowienie);
                    break;
                case StanZamowienia.Opóznione:
                    Oczekuje(zamowienie);
                    break;
                case StanZamowienia.Zrealizowane:
                    Zrealizowane(zamowienie);
                    break;
            }
        }
    }
}
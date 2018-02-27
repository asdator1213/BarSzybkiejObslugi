using BarSzybkiejObsługiMVC.DAL;
using BarSzybkiejObsługiMVC.Models;
using BarSzybkiejObsługiMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BarSzybkiejObsługiMVC.Utility
{
    public static class ZamowienieUtil
    {

        public static void WypelnijZamowienie(this Zamowienie zamowienieDoDodania,
            ZamowienieViewModel zamowienie)
        {
            zamowienieDoDodania.DataDodania = DateTime.Now;

            Klient klient = new Klient
            {
                Imie = zamowienie.Imie,
                Nazwisko = zamowienie.Nazwisko,
                Telefon = zamowienie.Telefon,
                Email = zamowienie.Email,
            };

            if (CzyKlientIstnieje(klient))
            {
                zamowienieDoDodania.KlientId = ZwrocIdKlienta(klient);
            }
            else
            {
                zamowienieDoDodania.Klient = new Klient
                {
                    Imie = zamowienie.Imie,
                    Nazwisko = zamowienie.Nazwisko,
                    Telefon = zamowienie.Telefon,
                    Email = zamowienie.Email
                };
            }


            zamowienieDoDodania.Komentarz = zamowienie.Komentarz;
            zamowienieDoDodania.NaKiedy = zamowienie.NaKiedy;
            zamowienieDoDodania.Platnosc = new Platnosc()
            {
                TypPlatnosci = zamowienie.TypPlatnosci
            };
            zamowienieDoDodania.KodZamowienia = CodeGenerator.Generate();
            zamowienieDoDodania.PozycjeZamowienia = new List<PozycjeZamowienia>();
        }

        private static bool CzyKlientIstnieje(Klient klient)
        {
            bool result = false;
            using (var db = new BarContext())
            {
                result = db.Klienci.Any(k => k.Imie == klient.Imie
                   && k.Nazwisko == klient.Nazwisko
                   && k.Telefon == klient.Telefon
                   && k.Email == klient.Email);

            }
            return result;
        }

        private static int ZwrocIdKlienta(Klient klient)
        {
            int id = 0;
            using (var db = new BarContext())
            {
                id = db.Klienci.First(k => k.Imie == klient.Imie
                        && k.Nazwisko == klient.Nazwisko
                        && k.Telefon == klient.Telefon
                        && k.Email == klient.Email).Id;
            }
            return id;
        }


        public static void DodajPozycjeKoszyka(this Zamowienie zamowienieDoDodania, List<PozycjaKoszyka> koszyk)
        {

            decimal koszykWartosc = 0;
            foreach (var koszykElement in koszyk)
            {
                var nowaPozycjaZamowienia = new PozycjeZamowienia()
                {
                    ProduktyId = koszykElement.Produkt.ProduktId,
                    Ilosc = koszykElement.Ilosc,
                    CenaZakupu = koszykElement.Produkt.Cena
                };

                koszykWartosc += (koszykElement.Ilosc * koszykElement.Produkt.Cena);
                zamowienieDoDodania.PozycjeZamowienia.Add(nowaPozycjaZamowienia);
            }
            zamowienieDoDodania.Platnosc.Kwota = koszykWartosc;
        }

        public static void UzupelnijZamowienieViewModel(this ZamowienieViewModel zamowienie,
            Zamowienie zamowienieDoDodania)
        {
            zamowienie.DataDodania = zamowienieDoDodania.DataDodania;
            zamowienie.PozycjeZamowienia = zamowienieDoDodania.PozycjeZamowienia;
            zamowienie.WartoscZamowienia = zamowienieDoDodania.Platnosc.Kwota;
            zamowienie.ZamowienieId = zamowienieDoDodania.ZamowienieId;
            zamowienie.NaKiedy = zamowienieDoDodania.NaKiedy;
            zamowienie.KodZamowienia = zamowienieDoDodania.KodZamowienia;
        }
    }
}
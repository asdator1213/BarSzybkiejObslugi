using BarSzybkiejObsługiMVC.DAL;
using BarSzybkiejObsługiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BarSzybkiejObsługiMVC.ViewModels;

namespace BarSzybkiejObsługiMVC.Infrastructure
{
    public class KoszykManager
    {

        private ISessionManager session;
        private BarContext db;

        public KoszykManager(ISessionManager session, BarContext db)
        {
            this.session = session;
            this.db = db;
        }

        public List<PozycjaKoszyka> PobierzKoszyk()
        {
            List<PozycjaKoszyka> koszyk;
            if(session.Get<List<PozycjaKoszyka>>(Const.KoszykSessionKlucz) == null)
            {
                koszyk = new List<PozycjaKoszyka>();
            }
            else
            {
                koszyk = session.Get<List<PozycjaKoszyka>>(Const.KoszykSessionKlucz) as List<PozycjaKoszyka>;
            }

            return koszyk;
        }

        public void DodajDoKoszyka(int produktId)
        {
            var koszyk = PobierzKoszyk();
            
            var pozycjaKoszyka = koszyk.Find(p => p.Produkt.ProduktId == produktId);
            // sprawdzenie czy dana pozycja już jest w koszyku
            if (pozycjaKoszyka != null)
            {
                //jeśli istnieje to zwiększam jej ilość
                pozycjaKoszyka.Ilosc++;
            }
            else
            {
                
                var produktDoDodania = db.Produkty.SingleOrDefault(p => p.ProduktId == produktId);

                if(produktDoDodania!=null)
                {
                    //jeśli jej nie ma, to dodaję nową pozycję do koszyka
                    var nowaPozycjaKoszyka = new PozycjaKoszyka
                    {
                        Produkt = produktDoDodania,
                        Ilosc = 1,
                        Wartosc = produktDoDodania.Cena
                    };
                    koszyk.Add(nowaPozycjaKoszyka);
                }

            }
            session.Set(Const.KoszykSessionKlucz, koszyk);
        }

        public int UsunZKoszyka(int produktId)
        {
            var koszyk = PobierzKoszyk();
            var pozycjaKoszyka = koszyk.Find(p => p.Produkt.ProduktId == produktId);

            if(pozycjaKoszyka != null)
            {
                if(pozycjaKoszyka.Ilosc>1)
                {
                    pozycjaKoszyka.Ilosc--;
                    return pozycjaKoszyka.Ilosc;
                }
                else
                {
                    koszyk.Remove(pozycjaKoszyka);
                }
            }
            return 0;
        }

        public int UsunWszystkoZKoszyka()
        {
            var koszyk = PobierzKoszyk();
            koszyk.Clear();
            return 0;
        }

        public decimal PobierzWartoscKoszyka()
        {
            var koszyk = PobierzKoszyk();
            return koszyk.Sum(p => p.Ilosc * p.Produkt.Cena);
        }

        public int PobierzIloscPozycjiKoszyka()
        {
            var koszyk = PobierzKoszyk();
            int ilosc = koszyk.Sum(p => p.Ilosc);
            return ilosc;
        }

        public ZamowienieViewModel UtworzZamowienie(ZamowienieViewModel zamowienie)
        {
            var koszyk = PobierzKoszyk();

            var zamowienieDoDodania = new Zamowienie()
            {
                DataDodania = DateTime.Now,
                Klient = new Klient
                {
                    Imie = zamowienie.Imie,
                    Nazwisko = zamowienie.Nazwisko,
                    Telefon = zamowienie.Telefon,
                    Email = zamowienie.Email
                },   
                Komentarz = zamowienie.Komentarz,
                NaKiedy = zamowienie.NaKiedy,
                Platnosc = new Platnosc()
                {
                    TypPlatnosci = zamowienie.TypPlatnosci
                }
            };

            db.Zamowienia.Add(zamowienieDoDodania);

            if(zamowienieDoDodania.PozycjeZamowienia == null)
            {
                zamowienieDoDodania.PozycjeZamowienia = new List<PozycjeZamowienia>();
            }
            decimal koszykWartosc = 0;
            foreach(var koszykElement in koszyk)
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

            var czasPrzygotowania = koszyk.Max(p => p.Produkt.CzasPrzygotowania);

            zamowienieDoDodania.Platnosc.Kwota = koszykWartosc;

            db.SaveChanges();
            zamowienieDoDodania.PlatnoscId = zamowienieDoDodania.Platnosc.Id;
            db.SaveChanges();

            zamowienie.DataDodania = zamowienieDoDodania.DataDodania;
            zamowienie.PozycjeZamowienia = zamowienieDoDodania.PozycjeZamowienia;
            zamowienie.WartoscZamowienia = zamowienieDoDodania.Platnosc.Kwota;
            zamowienie.ZamowienieId = zamowienieDoDodania.ZamowienieId;

            zamowienie.NaKiedy = zamowienieDoDodania.NaKiedy;

            return zamowienie;
        }

        public void PustyKoszyk()
        {
            session.Set<List<PozycjaKoszyka>>(Const.KoszykSessionKlucz, null);
        }
    }
}
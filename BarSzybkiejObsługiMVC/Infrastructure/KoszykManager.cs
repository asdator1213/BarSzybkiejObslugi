using BarSzybkiejObsługiMVC.DAL;
using BarSzybkiejObsługiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BarSzybkiejObsługiMVC.ViewModels;
using BarSzybkiejObsługiMVC.Utility;

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
            if (pozycjaKoszyka != null)
            {
                pozycjaKoszyka.Ilosc++;
            }
            else
            {
                
                var produktDoDodania = db.Produkty.SingleOrDefault(p => p.ProduktId == produktId);

                if(produktDoDodania!=null)
                {
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

            var zamowienieDoDodania = new Zamowienie();
            zamowienieDoDodania.WypelnijZamowienie(zamowienie);
            zamowienieDoDodania.DodajPozycjeKoszyka(koszyk);

            db.Zamowienia.Add(zamowienieDoDodania);
            db.SaveChanges();

            zamowienieDoDodania.PlatnoscId = zamowienieDoDodania.Platnosc.Id;
            db.SaveChanges();
            zamowienie.UzupelnijZamowienieViewModel(zamowienieDoDodania);

            return zamowienie;
        }

        public void PustyKoszyk()
        {
            session.Set<List<PozycjaKoszyka>>(Const.KoszykSessionKlucz, null);
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarSzybkiejObsługiMVC.Models
{
    public class Zamowienie
    {
        public int ZamowienieId { get; set; }
        public string Komentarz { get; set; }

        //public TypPlatnosci TypPlatnosci { get; set; }

        public DateTime DataDodania { get; set; }
        public StanZamowienia StanZamowienia { get; set; }
        //public decimal WartoscZamowienia { get; set; }

        public DateTime NaKiedy { get; set; }

        public int KlientId { get; set; }
        public virtual Klient Klient { get; set; }

        public int PlatnoscId { get; set; }
        public virtual Platnosc Platnosc { get; set; }

        public List<PozycjeZamowienia> PozycjeZamowienia { get; set; }
    }

    public enum StanZamowienia
    {
        Nowe,
        Zrealizowane,
        Opóźnione,
        Niezrealizowane
        //
    }

    public enum TypPlatnosci
    {
        Gotowka,
        Przelew,
        Karta
    }
}
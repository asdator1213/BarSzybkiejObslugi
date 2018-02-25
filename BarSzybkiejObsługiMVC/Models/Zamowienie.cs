using System;
using System.Collections.Generic;

namespace BarSzybkiejObsługiMVC.Models
{
    public class Zamowienie
    {
        public int ZamowienieId { get; set; }
        public string KodZamowienia { get; set; }
        public string Komentarz { get; set; }
        public DateTime DataDodania { get; set; }
        public StanZamowienia StanZamowienia { get; set; }
        public DateTime NaKiedy { get; set; }

        public int KlientId { get; set; }
        public virtual Klient Klient { get; set; }

        public int PlatnoscId { get; set; }
        public virtual Platnosc Platnosc { get; set; }

        public List<PozycjeZamowienia> PozycjeZamowienia { get; set; }
    }
}
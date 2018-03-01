namespace BarSzybkiejObsługiMVC.Models
{
    public class PozycjeZamowienia
    {
        public int PozycjeZamowieniaId { get; set; }
        public int ZamowienieId { get; set; }
        public int ProduktId { get; set; }
        public int Ilosc { get; set; }
        public decimal CenaZakupu { get; set; }

        public virtual Produkt Produkt { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }

    }
}
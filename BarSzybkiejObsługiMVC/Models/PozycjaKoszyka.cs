namespace BarSzybkiejObsługiMVC.Models
{
    public class PozycjaKoszyka
    {
        public Produkt Produkt { get; set; }
        public int Ilosc { get; set; }
        public decimal Wartosc { get; set; }
    }
}
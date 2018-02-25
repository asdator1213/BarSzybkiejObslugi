namespace BarSzybkiejObsługiMVC.Models
{
    public class PozycjeZamowienia
    {
        public int PozycjeZamowieniaId { get; set; }
        public int ZamowienieId { get; set; }
        public int ProduktyId { get; set; }
        public int Ilosc { get; set; }
        public decimal CenaZakupu { get; set; }

        public virtual Produkt Produkt { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }

    }
}
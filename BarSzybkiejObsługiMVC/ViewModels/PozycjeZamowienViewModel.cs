using BarSzybkiejObsługiMVC.Models;
using System.Collections.Generic;

namespace BarSzybkiejObsługiMVC.ViewModels
{
    public class PozycjeZamowienViewModel
    {
        public int ProduktId { get; set; }
        public List<PozycjeZamowienia> PozycjeZamowienia { get; set; }
        public int IloscProduktu { get; set; }
    }
}
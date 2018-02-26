using BarSzybkiejObsługiMVC.Models;
using System.Collections.Generic;

namespace BarSzybkiejObsługiMVC.ViewModels
{
    public class KoszykViewModel
    {
        public List<PozycjaKoszyka> PozycjeKoszyka { get; set; }
        public decimal CenaCałkowita { get; set; }

    }
}
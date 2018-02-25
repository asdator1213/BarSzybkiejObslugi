using BarSzybkiejObsługiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarSzybkiejObsługiMVC.ViewModels
{
    public class KoszykViewModel
    {
        public List<PozycjaKoszyka> PozycjeKoszyka { get; set; }
        public decimal CenaCałkowita { get; set; }

    }
}
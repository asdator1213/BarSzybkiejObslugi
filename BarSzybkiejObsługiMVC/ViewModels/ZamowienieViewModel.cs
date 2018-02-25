using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BarSzybkiejObsługiMVC.Models;

namespace BarSzybkiejObsługiMVC.ViewModels
{
    public class ZamowienieViewModel
    {
        public int ZamowienieId { get; set; }

        [Required(ErrorMessage = "Wprowadz imię")]
        [StringLength(50)]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Wprowadz nazwisko")]
        [StringLength(50)]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić numer telefonu")]
        [StringLength(20)]
        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Błędny format numeru telefonu.")]
        public string Telefon { get; set; }

        [EmailAddress(ErrorMessage = "Błędny format adresu e-mail.")]
        public string Email { get; set; }

        public string Komentarz { get; set; }

        public DateTime DataDodania { get; set; }
        public StanZamowienia StanZamowienia { get; set; }
        public decimal WartoscZamowienia { get; set; }
        public string KodZamowienia { get; set; }

        public int CzasOczekiwania { get; set; }
        public DateTime NaKiedy { get; set; }
        public List<PozycjeZamowienia> PozycjeZamowienia { get; set; }
        public List<PozycjaKoszyka> PozycjeKoszyka { get; set; }


        public TypPlatnosci TypPlatnosci { get; set; }

    }
}
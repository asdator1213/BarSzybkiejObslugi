using System.ComponentModel.DataAnnotations;

namespace BarSzybkiejObsługiMVC.Models
{
    public class Produkt
    {
        public int ProduktId { get; set; }

        [Required(ErrorMessage = "Podaj nazwę produktu.")]
        public string NazwaProduktu { get; set; }

        [Required(ErrorMessage = "Podaj cenę za produkt.")]
        public decimal Cena { get; set; }

        [Required(ErrorMessage = "Podaj czas przygotowania produktu.")]
        [Display(Name = "Czas przygotowania")]
        public int CzasPrzygotowania { get; set; }

        public bool Polecany { get; set; }
        public bool Ukryty { get; set; }
        public string NazwaPlikuObrazka { get; set; }
        
        public int KategoriaId { get; set; }
        public virtual Kategoria Kategoria { get; set; }

        public int OpisyId { get; set; }
        public virtual Opisy Opisy { get; set; }
    }
}
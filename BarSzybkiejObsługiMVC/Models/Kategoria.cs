using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BarSzybkiejObsługiMVC.Models
{
    public class Kategoria
    {
        public int KategoriaId { get; set; }
        [Required(ErrorMessage = "Podaj nazwę kategorii.")]
        public string NazwaKategorii { get; set; }
        public string OpisKategorii { get; set; }
        public string NazwaPlikuIkony { get; set; }

        public virtual ICollection<Produkt> Produkty { get; set; }
        
    }
}
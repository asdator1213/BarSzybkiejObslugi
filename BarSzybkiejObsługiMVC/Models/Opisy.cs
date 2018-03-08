using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BarSzybkiejObsługiMVC.Models
{
    public class Opisy
    {
        public int OpisyId { get; set; }
        public string Opis { get; set; }
        [Display(Name = "Krótki opis")]
        public string OpisKrotki { get; set; }

        public virtual ICollection<Produkt> Produkty { get; set; }
    }
}
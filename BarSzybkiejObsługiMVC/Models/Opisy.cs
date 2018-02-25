using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarSzybkiejObsługiMVC.Models
{
    public class Opisy
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public string OpisKrotki { get; set; }

        public virtual ICollection<Produkt> Produkty { get; set; }
    }
}
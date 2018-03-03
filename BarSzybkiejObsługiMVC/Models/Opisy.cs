﻿using System.Collections.Generic;

namespace BarSzybkiejObsługiMVC.Models
{
    public class Opisy
    {
        public int OpisyId { get; set; }
        public string Opis { get; set; }
        public string OpisKrotki { get; set; }

        public virtual ICollection<Produkt> Produkty { get; set; }
    }
}
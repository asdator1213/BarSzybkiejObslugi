﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarSzybkiejObsługiMVC.Models
{
    public class Platnosc
    {
        [ForeignKey("Zamowienie")]
        public int Id { get; set; }
        public DateTime? DataPlatnosci { get; set; }
        public TypPlatnosci TypPlatnosci { get; set; }
        public decimal Kwota { get; set; }
        public bool CzyZaplacono { get; set; }

        public virtual Zamowienie Zamowienie { get; set; }
    }
}
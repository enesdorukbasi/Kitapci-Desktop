﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapciApp.EntityLayer
{
    public class SatısDetay
    {
        public int Id { get; set; }

        public int SatısId { get; set; }
        [ForeignKey("SatısId")]
        public Satıs Satıs { get; set; }

        public int KitapId { get; set; }
        [ForeignKey("KitapId")]
        public Kitap Kitap { get; set; }
        public int Adet { get; set; }

        public decimal Tutar { get; set; }
    }
}

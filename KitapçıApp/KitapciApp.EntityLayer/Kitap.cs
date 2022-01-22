using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapciApp.EntityLayer
{
    [Table("tblKitaplar")]
    public class Kitap
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Barkod { get; set; }
        [Required]
        public string KitapAd { get; set; }
        [Required]
        public string Yazar { get; set; }
        public int TurId { get; set; }
        [ForeignKey("TurId")]
        public virtual Tur Tur { get; set; }
        [Required]
        public int Adet { get; set; }
        [Required]
        public decimal Fiyat { get; set; }
    }
}

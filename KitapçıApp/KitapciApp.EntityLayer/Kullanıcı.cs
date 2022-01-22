using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapciApp.EntityLayer
{
    public enum Yetkiler
    {
        Yonetici = 1,
        Satici = 2
    }

    [Table("tblKullanıcılar")]
    public class Kullanıcı
    {
        [Key, Required]
        public string KullanıcıNo { get; set; }
        [Required, MinLength(4, ErrorMessage = "Minimum 4 karakter olmalıdır.")]
        public string Parola { get; set; }
        [Required]
        public string Ad { get; set; }
        [Required]
        public string Soyad { get; set; }
        [Required]
        public Yetkiler Yetki { get; set; }

    }
}

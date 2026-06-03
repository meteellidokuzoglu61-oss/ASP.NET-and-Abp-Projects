using System;
using System.ComponentModel.DataAnnotations;

namespace OgrenciApp.Models
{
    public class Devamsizlik
    {
        public int Id { get; set; }


        public string Ogrenci_AdSoyad { get; set; }

        [Required]
        public DateTime Tarih { get; set; }

        [StringLength(50)]
        public string Durum { get; set; }

        [StringLength(200)]
        public string Aciklama { get; set; }
    }
}

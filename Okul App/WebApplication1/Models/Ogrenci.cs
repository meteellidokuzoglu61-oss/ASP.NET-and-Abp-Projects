using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace OgrenciApp.Models
{
    [Table("Ogrenciler", Schema = "dbo")]
    public class Ogrenci
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Ogrenci_ID { get; set; }

        [Required(ErrorMessage = "Ad Soyad zorunludur.")]
        [StringLength(50)]
        public string Ogrenci_AdiSoyadi { get; set; }

        [StringLength(5)]
        public string Ogrenci_Sinifi { get; set; }

        public string Ogrenci_Subesi { get; set; }

        public int Numarasi { get; set; } 

        public int Sinif_Id { get; set; }

        [Required]
        public string Ogrenci_Bolumu { get; set; }

        public string? Ogrenci_Cinsiyeti { get; set; }
        public decimal? Ogrenci_Telefon { get; set; }

        [Required]
        public string Ogrenci_Emaili { get; set; }

        public string? Ogrenci_Fotografi { get; set; }
    }
}




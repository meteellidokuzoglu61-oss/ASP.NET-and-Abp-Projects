using System.ComponentModel.DataAnnotations;
using OgrenciApp.Models;
using WebApplication1.Models;
namespace OgrenciApp.Models
{
    public class Bolum
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Bolum_Ad { get; set; }  // Bölüm adı

        [Required]
        public string KayitDonemi { get; set; }

        public ICollection<Sinif> Sinif { get; set; } // 1 bölümün birden fazla sınıfı olabilir

    }
}

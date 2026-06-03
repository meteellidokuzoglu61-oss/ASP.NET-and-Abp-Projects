using System.ComponentModel.DataAnnotations;

namespace OgrenciApp.Models
{
    public class Not
    {
        public int Id { get; set; }

        public int OgrenciId { get; set; }

        public string OgrenciAd { get; set; }

        public string DersAd { get; set; }
        public int DersId { get; set; }

        public int? Proje { get; set; }
        public int? YaziliSinav { get; set; }
        public int? Sozlu { get; set; }

        [Required]
        public int Donem { get; set; } // 1 veya 2
    }
}

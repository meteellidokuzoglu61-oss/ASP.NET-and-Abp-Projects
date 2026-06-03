using System.ComponentModel.DataAnnotations;

namespace OgrenciApp.Models
{
    public class Ders
    {
        public int Id { get; set; }



        public int Ogretmen_ID { get; set; }

        [Required]
        public string DersAdi { get; set; }

        public string Kod { get; set; }



        [Required]
        public string DersBransi { get; set; }  // Öğretmenin branşı ile eşleşecek

        [Required]
        public string DersSubesi { get; set; }  // Ör: 10A, 11B

        public int DersSaati { get; set; }      // Zorunlu değil
    }
}

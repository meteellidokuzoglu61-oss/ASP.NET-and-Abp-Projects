using System.ComponentModel.DataAnnotations;

namespace OgrenciApp.Models

{
    public class Ogretmen
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad Soyad zorunludur.")]
        public string Ogretmen_AdiSoyadi { get; set; }

        [Required(ErrorMessage = "Doğum Tarihi zorunludur.")]

        public DateTime Ogretmen_DogumTarihi { get; set; }

        [Required]
        public string Ogretmen_Bransi { get; set; }

        public string Ogretmen_Subesi { get; set; }

        
        
        [Required(ErrorMessage = "Telefon zorunludur.")]


        public decimal Ogretmen_Telefon { get; set; }

        [Required(ErrorMessage = "Email zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email giriniz.")]
        public string Ogretmen_Emaili { get; set; }

        public string? Ogretmen_Fotografi { get; set; }
    }
}

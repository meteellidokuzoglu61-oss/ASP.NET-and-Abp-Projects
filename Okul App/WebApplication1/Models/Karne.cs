namespace OgrenciApp.Models
{
    public class Karne
    {
        public int Id { get; set; }

        public string Ogrenci_AdSoyad { get; set; } // Örn: Mete Ellidokuzoğlu

        public string Ogrenci_Bolumu { get; set; }

        public string Ders_Adi { get; set; } // Örn: Matematik

        public int Notlar { get; set; } // Örn: 85

        public string Davranis_Notu { get; set; } // Örn: İyi
    }
}

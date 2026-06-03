namespace OgrenciApp.Models
{
    public class DersProgrami
    {
        public int Id { get; set; }

        public int SinifId { get; set; }
        public Sinif Sinif { get; set; }

        public string DersAdi { get; set; }
        public string Ogretmen { get; set; }

        public DayOfWeek Gun { get; set; } // Pazartesi, Salı...
        public int DersSaati { get; set; } // 1. Ders, 2. Ders...





    }
}

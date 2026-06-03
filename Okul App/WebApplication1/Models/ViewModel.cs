using System.Collections.Generic;

namespace OgrenciApp.Models
{
    public class TopluNotViewModel
    {
        public int Donem { get; set; }

        public List<OgrenciView> Ogrenciler { get; set; }
        public List<DersView> Dersler { get; set; }

        public List<NotInput> Notlar { get; set; } = new();
    }

    public class OgrenciView
    {
        public string AdSoyad { get; set; }
        public string Numara { get; set; } // ID yerine
    }

    public class DersView
    {
        public string Ad { get; set; }
        public string Kod { get; set; } // ID yerine
    }

    public class NotInput
    {
        public string OgrenciNumara { get; set; }
        public string DersKod { get; set; }

        public int? Proje { get; set; }
        public int? YaziliSinav { get; set; }
        public int? Sozlu { get; set; }
    }
}

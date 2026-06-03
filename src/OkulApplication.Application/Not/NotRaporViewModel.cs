namespace OkulApplication.Notlar.ViewModels
{
    public class OgrenciNotRaporViewModel
    {
        public string OgrenciAdiSoyadi { get; set; }
        public string Sinif { get; set; }     // 10-A gibi
        public string Sube { get; set; }      // A, B, C gibi
        public string Ders { get; set; }
        public decimal Sozlu { get; set; }
        public decimal Yazili { get; set; }
        public decimal Proje { get; set; }

        public decimal Ortalama { get; set; }
    }
}

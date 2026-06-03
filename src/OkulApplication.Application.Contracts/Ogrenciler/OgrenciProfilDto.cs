using System;

namespace OkulApplication.Ogrenciler.Dtos
{
    public class OgrenciProfilDto
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Sinif { get; set; }
        public int Numara { get; set; }
        public string? FotografYolu { get; set; }
    }
}

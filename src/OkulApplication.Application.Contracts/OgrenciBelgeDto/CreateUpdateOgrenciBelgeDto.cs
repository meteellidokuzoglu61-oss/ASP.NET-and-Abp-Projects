using System;
using System.Collections.Generic;
using System.Text;

namespace OkulApplication.Ogrenci_Belgeler
{
   public class CreateUpdateOgrenciBelgeDto
    {
        public Guid OgrenciId { get; set; }
        public string BelgeAdi { get; set; }

        public string DosyaTuru { get; set; }
        public DateTime YuklemeTarihi { get; set; }
        public string DosyaYolu { get; set; } // 👈 EKLE




    }



}

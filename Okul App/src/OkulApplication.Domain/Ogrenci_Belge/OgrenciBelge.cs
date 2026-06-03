using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace OkulApplication.Ogrenci_Belgeler
{
    public class OgrenciBelge : Entity<Guid>
    {
        public Guid OgrenciId {  get; set; }
        public string BelgeAdi { get; set; }
        public string DosyaYolu { get; set; }
        public string DosyaTuru { get; set; }
        public DateTime YuklemeTarihi { get; set; }
        public bool Aktif { get; set; }





    }
}

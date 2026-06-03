using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace OkulApplication.Ogrenci_Belgeler
{
    public class OgrenciBelgeDto : EntityDto<Guid>
    {
        public Guid OgrenciId { get; set; }
        public string BelgeAdi { get; set; }
        public string DosyaTuru { get; set; }
        public DateTime YuklemeTarihi { get; set; }
    }
}

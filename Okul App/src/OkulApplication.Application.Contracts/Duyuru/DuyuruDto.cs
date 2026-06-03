using System;
using Volo.Abp.Application.Dtos;

namespace OkulApplication.Duyurular
{
    public class DuyuruDto : EntityDto<Guid>
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime YayimTarihi { get; set; }
    }
}

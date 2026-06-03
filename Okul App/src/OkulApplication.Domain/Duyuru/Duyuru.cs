using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace OkulApplication.Duyurular
{
    public class Duyuru : FullAuditedAggregateRoot<Guid>
    {
        public string Baslik {  get; set; }
        public string Icerik { get; set; }

        public DateTime YayimTarihi { get; set; }

        public Duyuru () { }



    }
}

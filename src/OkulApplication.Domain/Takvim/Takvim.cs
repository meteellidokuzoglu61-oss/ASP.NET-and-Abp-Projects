using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace OkulApplication.Takvimler
{
    public class Takvim : AuditedAggregateRoot<Guid>
    {
        public string Baslik { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }

        public TakvimEtkinlikTipi Tip { get; set; }

        public Guid? DersId { get; set; } // Opsiyonel
    }
}

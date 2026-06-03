using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;


namespace OkulApplication.Devamsizlik
{
    public class DevamsizlikKaydi: AuditedAggregateRoot<Guid>
    {
        public Guid OgrenciId { get; set; }
        public DateTime Devamsizlik_Tarihi { get; set; }
        public Devamsizlik_Tipi Tip {  get; set; }
    }
}

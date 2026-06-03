using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

public class Dersler : FullAuditedAggregateRoot<Guid>
{
    public string Ad { get; set; }
    public string Kodu { get; set; }
    public int Kredi { get; set; }

    

}

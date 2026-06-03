using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace OkulApplication.Mufredatlar;

public class Mufredat : AuditedAggregateRoot<Guid>
{
    public Guid DersId { get; set; }      // 📘 Ders
    public int Sinif { get; set; }         // 🏫 Sınıf
    public int Donem { get; set; }         // 📅 Dönem
}

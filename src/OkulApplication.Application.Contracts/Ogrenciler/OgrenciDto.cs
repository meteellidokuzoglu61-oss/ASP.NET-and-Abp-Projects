using System;
using Volo.Abp.Application.Dtos;

namespace OkulApplication.Ogrenciler;

public class OgrenciDto : AuditedEntityDto<Guid>
{
    public string Ogrenci_AdiSoyadi { get; set; }

    public Bolum Ogrenci_Bolumu { get; set; }

    public string Ogrenci_Sinifi { get; set; }

    public string Ogrenci_Subesi { get; set; }

    public DateTime Ogrenci_DogumTarihi { get; set; }

    public int Numarasi { get; set; }
}

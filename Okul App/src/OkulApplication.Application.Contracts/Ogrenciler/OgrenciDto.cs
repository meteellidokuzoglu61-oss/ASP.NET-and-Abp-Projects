using System;
using Volo.Abp.Application.Dtos;
using OkulApplication.Ogrenciler;
using System.ComponentModel.DataAnnotations;

namespace OkulApplication.Ogrenciler;

public class OgrenciDto : AuditedEntityDto<Guid>
{
    public string Ogrenci_AdiSoyadi { get; set; }

    public Bolum Ogrenci_Bolumu { get; set; }

    public string Ogrenci_Sinifi { get; set; }

    public string Ogrenci_Subesi { get; set; }

    [StringLength(5)]
    public string Email { get; set; }

    public DateTime Ogrenci_DogumTarihi { get; set; }

    public int Numarasi { get; set; }

    public decimal Sozlu { get; set; }
    public decimal Yazili { get; set; }
    public decimal Proje { get; set; }
    public decimal Ortalama { get; set; }
}

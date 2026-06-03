using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace OkulApplication.Ogrenciler;

public class Ogrenci: AuditedAggregateRoot<Guid>
{



    [Required(ErrorMessage = "Ad Soyad zorunludur.")]
    public string Ogrenci_AdiSoyadi { get; set; }

    [StringLength(5)]
    [Required]
    public string Ogrenci_Sinifi { get; set; }

    [StringLength(5)]
    [Required]
    public string Ogrenci_Subesi { get; set; }

    [StringLength(5)]
    public string Email { get; set; }

    public decimal Sozlu {  get; set; }

    public decimal Yazili { get; set; }
    public decimal Proje { get; set; }

    public DateTime Ogrenci_DogumTarihi { get; set; }

    public Bolum Ogrenci_Bolumu { get; set; }

    public decimal Ortalama { get; set; }

    public int Numarasi { get; set; }
}

using System;
using Volo.Abp.Application.Dtos;

namespace OkulApplication.Ogretmenler;

public class OgretmenDto : AuditedEntityDto<Guid>
{
    public string Ogretmen_AdiSoyadi { get; set; }

    public DateTime Ogretmen_DogumTarihi { get; set; }

    public string Ogretmen_BabaAdi { get; set; }

    public Branslar Ogretmen_Bransi { get; set; }

    public decimal Ogretmen_Telefon { get; set; }

    public string Ogretmen_Email { get; set; }

    public int Ogretmen_Sinif { get; set; }
    public string Ogretmen_Sube { get; set; }
}

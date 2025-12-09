using System;
using System.ComponentModel.DataAnnotations;

namespace OkulApplication.Ogretmenler;

public class CreateUpdateOgretmenDto
{
    [Required]
    [StringLength(128)]
    public string Ogretmen_AdiSoyadi { get; set; } = string.Empty;

    public string Ogretmen_BabaAdi { get; set; } 

    [Required]
    public Branslar Ogretmen_Bransi { get; set; } = Branslar.MakineVeTasarim_Teknolojisi;

    [Required]
    [DataType(DataType.Date)]
    public DateTime Ogretmen_DogumTarihi { get; set; } = DateTime.Now;

    [Required]
    [StringLength(128)]
    public string Ogretmen_Sinif {  get; set; } = string.Empty;

    [Required]
    [StringLength(128)]
    public string Ogretmen_Sube { get; set; }

}

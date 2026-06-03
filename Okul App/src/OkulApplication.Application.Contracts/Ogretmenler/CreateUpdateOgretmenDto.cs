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

    public DateTime Ogretmen_DogumTarihi { get; set; } 

    public decimal Ogretmen_Telefon { get; set; }

    [Required, StringLength(128)]

    public string Ogretmen_Email { get; set; }

    [Required]
    [StringLength(128)]
    public string Ogretmen_Sinif {  get; set; } = string.Empty;

    [Required]
    [StringLength(128)]
    public string Ogretmen_Sube { get; set; }

}

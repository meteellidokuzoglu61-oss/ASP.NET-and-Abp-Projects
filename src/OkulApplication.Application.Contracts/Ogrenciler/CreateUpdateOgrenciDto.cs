using System;
using System.ComponentModel.DataAnnotations;

namespace OkulApplication.Ogrenciler;

public class CreateUpdateOgrenciDto
{
    [Required]
    [StringLength(128)]
    public string Ogrenci_AdiSoyadi { get; set; } = string.Empty;

    [Required]
    public Bolum Ogrenci_Bolumu { get; set; } = Bolum.Bilişim_Teknolojileri;

    [Required]
    [DataType(DataType.Date)]
    public DateTime Ogrenci_DogumTarihi { get; set; } = DateTime.Now;

    [Required]
    [StringLength(128)]
    public string Ogrenci_Sinifi {  get; set; } = string.Empty;

    [Required]
    [StringLength(128)]
    public string Ogrenci_Subesi {  get; set; } = string.Empty;


    [Required]
    public int Numarasi { get; set; }
}

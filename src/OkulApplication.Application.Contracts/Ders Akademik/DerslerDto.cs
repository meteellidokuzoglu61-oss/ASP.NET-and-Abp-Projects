using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace OkulApplication.Ders_Akademik;

public class DerslerDto : AuditedEntityDto<Guid>
{
    [Required]
    [StringLength(128)]
    public string Ad { get; set; }

    [Required]
    [StringLength(64)]
    public string Kodu { get; set; }

    [Range(1, 10)]
    public int Kredi { get; set; }
    public Guid AkademisyenId { get; set; }

}

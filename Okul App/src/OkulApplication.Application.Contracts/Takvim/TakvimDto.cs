using System;
using Volo.Abp.Application.Dtos;

public class TakvimDto : EntityDto<Guid>
{
    public string Baslik { get; set; }
    public DateTime BaslangicTarihi { get; set; }
    public DateTime BitisTarihi { get; set; }
    public TakvimEtkinlikTipi Tip { get; set; }
}
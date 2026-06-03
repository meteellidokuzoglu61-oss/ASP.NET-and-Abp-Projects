using System;
using Volo.Abp.Application.Dtos;

namespace OkulApplication.Mufredatlar;

public class MufredatDto : EntityDto<Guid>
{
    public Guid DersId { get; set; }
    public int Sinif { get; set; }
    public int Donem { get; set; }
}

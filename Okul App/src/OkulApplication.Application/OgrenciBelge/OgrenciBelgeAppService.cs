using OkulApplication.Ogrenci_Belgeler;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

public class OgrenciBelgeAppService :
    CrudAppService<
        OgrenciBelge,
        OgrenciBelgeDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateOgrenciBelgeDto>,
    IOgrenciBelgeAppService
{
    public OgrenciBelgeAppService(IRepository<OgrenciBelge, Guid> repository)
        : base(repository)
    {
    }
}

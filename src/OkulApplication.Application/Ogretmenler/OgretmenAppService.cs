using OkulApplication.Ogretmenler;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace OkulApplication.Ogretmenler;

public class OgretmenAppService :
    CrudAppService<
        Ogretmen, //The Ogrenci entity
        OgretmenDto, //Used to show Ogrenci
        Guid, //Primary key of the ogrenci entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateOgretmenDto>, //Used to create/update a ogrenci
    IOgretmenAppService //implement the IBookAppService
{
    public OgretmenAppService(IRepository<Ogretmen, Guid> repository)
        : base(repository)
    {


    }

    [UnitOfWork] // 🔴 KRİTİK
    public override async Task<OgretmenDto> CreateAsync(CreateUpdateOgretmenDto input)
    {
        var entity = ObjectMapper.Map<CreateUpdateOgretmenDto, Ogretmen>(input);

        await Repository.InsertAsync(entity, autoSave: true);

        return ObjectMapper.Map<Ogretmen, OgretmenDto>(entity);
    }


}

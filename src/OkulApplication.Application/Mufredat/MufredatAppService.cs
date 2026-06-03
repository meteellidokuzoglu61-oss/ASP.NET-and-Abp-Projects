using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;


namespace OkulApplication.Mufredatlar;

public class MufredatAppService :
    CrudAppService<
        Mufredat,
        MufredatDto,
        Guid,
        Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto,
        CreateUpdateMufredatDto>,
        IMufredatAppService
    
{
    public MufredatAppService(IRepository<Mufredat, Guid> repository)
        : base(repository)
    {
    }
}

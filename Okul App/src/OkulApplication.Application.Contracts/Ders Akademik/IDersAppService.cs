using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OkulApplication.Ders_Akademik
{
    public interface IDersAppService :
        ICrudAppService<DerslerDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateDerslerDto>
    {

    }
}

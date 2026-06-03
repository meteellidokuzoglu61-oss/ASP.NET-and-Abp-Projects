using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OkulApplication.Mufredatlar
{
    public interface IMufredatAppService :
          ICrudAppService<MufredatDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateMufredatDto>
    { }
}

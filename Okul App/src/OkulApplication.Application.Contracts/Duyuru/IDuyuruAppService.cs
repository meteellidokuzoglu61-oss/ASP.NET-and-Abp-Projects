using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;

namespace OkulApplication.Duyurular
{
    public interface IDuyuruAppService
        : ICrudAppService<
            DuyuruDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateDuyuruDto>
    {
    }
}

using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace OkulApplication.Duyurular
{
    public class DuyuruAppService
        : CrudAppService<
            Duyuru,
            DuyuruDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateDuyuruDto>,
          IDuyuruAppService
    {
        public DuyuruAppService(IRepository<Duyuru, Guid> repository)
            : base(repository)
        {
        }
    }
}

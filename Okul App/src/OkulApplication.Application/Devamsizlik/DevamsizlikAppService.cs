using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;


namespace OkulApplication.Devamsizlik
{
    public class DevamsizlikAppService : CrudAppService<
     DevamsizlikKaydi,
     DevamsizlikDto,
     Guid,
     PagedAndSortedResultRequestDto,
     CreateUpdateDevamsizlikDto>,
        IDevamsizlikAppService
    {
        public DevamsizlikAppService(IRepository<DevamsizlikKaydi, Guid> repository)
            : base(repository)
        {

        }
    }


}

using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OkulApplication.Devamsizlik
{
    public interface IDevamsizlikAppService :
          ICrudAppService<DevamsizlikDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateDevamsizlikDto>
    { }
}

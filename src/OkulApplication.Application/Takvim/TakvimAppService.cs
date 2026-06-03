using Microsoft.AspNetCore.Authorization;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace OkulApplication.Takvimler
{
    [AllowAnonymous]
    public class TakvimAppService :
     CrudAppService<
         Takvim,
         TakvimDto,
         Guid,
         PagedAndSortedResultRequestDto,
         CreateUpdateTakvimDto>,
        ITakvimAppService
    {
        public TakvimAppService(
            IRepository<Takvim, Guid> repository)
            : base(repository)
        {
           
        }
    }
}

using Microsoft.Extensions.Logging;
using OkulApplication.Ders_Akademik;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Users;

namespace OkulApplication.Ders_Akademik
{
    public class DersAppService :
        CrudAppService<
            Dersler,
            DerslerDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateDerslerDto>,
        IDersAppService
    {
        private readonly ICurrentUser _currentUser;


        public DersAppService(
            IRepository<Dersler, Guid> repository,
            ICurrentUser currentUser)
            : base(repository)
        {
            _currentUser = currentUser;
        }

    

    ///public override async Task<DerslerDto> CreateAsync(CreateUpdateDerslerDto input)
      //  {
    //        Logger.LogError("CREATE ÇAĞRILDI");

      //      var entity = await MapToEntityAsync(input);
//
      //      await Repository.InsertAsync(entity, autoSave: true);
//      Logger.LogError("INSERT SONRASI");

       //     return MapToGetOutputDto(entity);
       // }
    }
}
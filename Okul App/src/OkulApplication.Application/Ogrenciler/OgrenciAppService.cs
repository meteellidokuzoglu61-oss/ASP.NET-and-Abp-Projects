using Microsoft.AspNetCore.Authorization;
using OkulApplication.Ogrenciler;
using OkulApplication.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using OkulApplication.Ogrenciler.Dtos;

namespace OkulApplication.Ogrenciler
{
    [AllowAnonymous]
    public class OgrenciAppService :
        CrudAppService<
            Ogrenci,
            OgrenciDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateOgrenciDto>,
        IOgrenciAppService
    {
      

        private readonly IRepository<Ogrenci, Guid> _ogrenciRepository;

     
        public OgrenciAppService(IRepository<Ogrenci, Guid> repository)
            : base(repository)
        {


            _ogrenciRepository = repository;

            GetPolicyName = OkulApplicationPermissions.Ogrenciler.Default;
            GetListPolicyName = OkulApplicationPermissions.Ogrenciler.Default;
            CreatePolicyName = OkulApplicationPermissions.Ogrenciler.Create;
            UpdatePolicyName = OkulApplicationPermissions.Ogrenciler.Edit;
            DeletePolicyName = OkulApplicationPermissions.Ogrenciler.Delete;
        }

        // Öğretmen bazlı öğrenci listesi
        public async Task<List<Ogrenci>> GetOgrencilerForOgretmenAsync(Guid ogretmenId)
        {
            var ogrenciler = await _ogrenciRepository.GetListAsync();

            // Ogrenci entity'sinde OgretmenId yoksa tüm öğrencileri döndür
            return ogrenciler.ToList();

            // Eğer OgretmenId varsa:
            // return ogrenciler.Where(o => o.OgretmenId == ogretmenId).ToList();
        }
    }
}

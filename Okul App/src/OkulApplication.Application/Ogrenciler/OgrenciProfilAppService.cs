using Microsoft.AspNetCore.Authorization;
using OkulApplication.Ogrenciler.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;

namespace OkulApplication.Ogrenciler
{
    [Authorize]
    public class OgrenciProfilAppService
        : ApplicationService, IOgrenciProfilAppService
    {
        private readonly IRepository<Ogrenci, Guid> _ogrenciRepository;

        public OgrenciProfilAppService(IRepository<Ogrenci, Guid> ogrenciRepository)
        {
            _ogrenciRepository = ogrenciRepository;
        }

        public async Task<OgrenciProfilDto> GetAsync()
        {
            var email = CurrentUser.Email;

            if (string.IsNullOrEmpty(email))
                throw new UserFriendlyException("Kullanıcı email bilgisi bulunamadı");

            var ogrenci = await _ogrenciRepository
                .FirstOrDefaultAsync(x => x.Email == email);

            return ObjectMapper.Map<Ogrenci, OgrenciProfilDto>(ogrenci);
        }
    }
}
    

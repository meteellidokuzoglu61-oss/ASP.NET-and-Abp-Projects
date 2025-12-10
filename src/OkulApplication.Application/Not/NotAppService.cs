using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using OkulApplication.Ogrenciler;
using OkulApplication.Notlar;

namespace OkulApplication.Notlar
{
    public class NotAppService : ApplicationService
    {
        private readonly IRepository<Not, Guid> _notRepository;
        private readonly IRepository<Ogrenci, Guid> _ogrenciRepository;

        public NotAppService(IRepository<Not, Guid> notRepository,
                             IRepository<Ogrenci, Guid> ogrenciRepository)
        {
            _notRepository = notRepository;
            _ogrenciRepository = ogrenciRepository;
        }

        // Öğretmenin şubesindeki öğrenciler
        public async Task<List<Ogrenci>> GetOgrencilerForOgretmenAsync(Guid ogretmenId)
        {
            var ogrenciler = await _ogrenciRepository.GetListAsync();
            return ogrenciler.Where(o => o.Ogrenci_Subesi == "A").ToList(); // örnek filtre
        }

        // Toplu not girişi
        public async Task TopluNotGirisAsync(List<Not> notlar)
        {
            foreach (var not in notlar)
            {
                await _notRepository.InsertAsync(not, autoSave: true);
            }
        }
    }
}

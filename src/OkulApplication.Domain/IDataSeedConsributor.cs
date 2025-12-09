using OkulApplication.Ogrenciler;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;

namespace OkulApplication.DataSeed
{
    public class OkulApplicationDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Ogrenci, Guid> _ogrenciRepository;
        public OkulApplicationDataSeederContributor(
            IRepository<Ogrenci, Guid> ogrenciRepository,
            IIdentityRoleRepository roleRepository,
            IPermissionManager permissionManager,
            ICurrentTenant currentTenant)
        {
            _ogrenciRepository = ogrenciRepository;
            
        }

        public async Task SeedAsync(DataSeedContext context)
        {
           

                // Örnek öğrenciler ekle
                if (await _ogrenciRepository.GetCountAsync() == 0)
                {
                    await _ogrenciRepository.InsertAsync(new Ogrenci
                    {
                        Ogrenci_AdiSoyadi = "Halim Bilici",
                        Ogrenci_Bolumu = Bolum.Bilişim_Teknolojileri,
                        Ogrenci_Sinifi = "12",
                        Ogrenci_Subesi = "A",
                        Ogrenci_DogumTarihi = new DateTime(2005, 10, 14),
                        Numarasi = 158
                    }, autoSave: true);

                    await _ogrenciRepository.InsertAsync(new Ogrenci
                    {
                        Ogrenci_AdiSoyadi = "Yıldırım Yemezci",
                        Ogrenci_Bolumu = Bolum.ElektrikElektronik_Teknolojisi,
                        Ogrenci_Sinifi = "12",
                        Ogrenci_Subesi = "A",
                        Ogrenci_DogumTarihi = new DateTime(2008, 6, 22),
                        Numarasi = 132
                    }, autoSave: true);
                }
            }
        }
    }

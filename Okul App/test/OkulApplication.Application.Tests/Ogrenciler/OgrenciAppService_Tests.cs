using System;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Xunit;
using OkulApplication.Ders_Akademik;
using Microsoft.Extensions.Hosting;

namespace OkulApplication.Ogrenciler;

public abstract class OgrenciAppService_Tests<TStartupModule> : OkulApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly IOgrencisAppService _ogrenciAppService;

    protected OgrenciAppService_Tests()
    {
        _ogrenciAppService = GetRequiredService<IOgrencisAppService>();
    }

    [Fact]
    public async Task Should_Get_List_Of_Students()
    {
        //Act
        var result = await _ogrenciAppService.GetListAsync(
            new PagedAndSortedResultRequestDto()
        );

        result.TotalCount.ShouldBeGreaterThan(0);
        result.Items.ShouldContain(b => b.Ogrenci_AdiSoyadi == "Ferhat Ertaş");
    }

    [Fact]
    public async Task Should_Create_A_Valid_Student()
    {
        // Act
        var result = await _ogrenciAppService.CreateAsync(
            new CreateUpdateOgrenciDto
            {
                Ogrenci_AdiSoyadi = "Aydın Ali",
                Numarasi = 10,
                Ogrenci_DogumTarihi = new DateTime(2008, 11, 1),
                Ogrenci_Bolumu = Bolum.ElektrikElektronik_Teknolojisi,
                Ogrenci_Sinifi = "10",
                Ogrenci_Subesi = "A",
                Yazili = 40,
                Sozlu = 100,
                Proje = 50
            }
        );
        // Assert
        result.Id.ShouldNotBe(Guid.Empty);
        result.Ogrenci_AdiSoyadi.ShouldBe("Ahmet Aydın");
    }

    [Fact]
    public async Task Should_Not_Create_A_Student_Without_Name()
    {
        var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
        {
            await _ogrenciAppService.CreateAsync(
                new CreateUpdateOgrenciDto
                {
                    Ogrenci_AdiSoyadi = null,
                    Numarasi = 10,
                    Ogrenci_DogumTarihi = DateTime.Now,
                    Ogrenci_Bolumu = Bolum.MakineVeTasarım_Teknolojisi,
                    Ogrenci_Sinifi = "12",
                    Ogrenci_Subesi = "A",
                    Yazili = 100,
                    Sozlu = 100,
                    Proje = 65
                }
            );
        });

        exception.ValidationErrors
            .ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));

    }
}

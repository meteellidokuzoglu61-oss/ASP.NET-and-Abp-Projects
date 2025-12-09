using System;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using OkulApplication.Ogrenciler;
using Xunit;

namespace OkulApplication.Ogrenciler;

public abstract class OgrenciAppService_Tests<TStartupModule> : OkulApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly IOgrenciAppService _ogrenciAppService;

    protected OgrenciAppService_Tests()
    {
        _ogrenciAppService = GetRequiredService<IOgrenciAppService>();
    }

    [Fact]
    public async Task Should_Get_List_Of_Students()
    {
        //Act
        var result = await _ogrenciAppService.GetListAsync(
            new PagedAndSortedResultRequestDto()
        );

        //Assert
        result.TotalCount.ShouldBeGreaterThan(0);
        result.Items.ShouldContain(b => b.Ogrenci_AdiSoyadi == "Ferhat Ertaş");
    }

    [Fact]
    public async Task Should_Create_A_Valid_Student()
    {
        //Act
        var result = await _ogrenciAppService.CreateAsync(
            new CreateUpdateOgrenciDto
            {
                Ogrenci_AdiSoyadi = "Ahmet Aydın",
                Numarasi = 10,
                Ogrenci_DogumTarihi = DateTime.Now,
                Ogrenci_Bolumu = Bolum.Bilişim_Teknolojileri
            }
        );

        //Assert
        result.Id.ShouldNotBe(Guid.Empty);
        result.Ogrenci_AdiSoyadi.ShouldBe("New test student Ahmet");
    }

    public async Task Should_Not_Create_A_Book_Without_Name()
    {
        var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
        {
            await _ogrenciAppService.CreateAsync(
                new CreateUpdateOgrenciDto
                {
                    Ogrenci_AdiSoyadi = "",
                    Numarasi = 10,
                    Ogrenci_DogumTarihi = DateTime.Now,
                    Ogrenci_Bolumu = Bolum.MakineVeTasarım_Teknolojisi
                }
            );
        });

        exception.ValidationErrors
            .ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));

    }
}

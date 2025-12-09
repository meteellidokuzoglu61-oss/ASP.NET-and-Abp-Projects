using System;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
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
        result.Items.ShouldContain(o => o.Ogrenci_AdiSoyadi == "Hasan Ertaş");
    }
}

using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using OkulApplication.Ogrenciler;

namespace OkulApplication.Blazor;

[Mapper]
public partial class OgrenciDtoToCreateUpdateOgrenciDtoMapper : MapperBase<OgrenciDto, CreateUpdateOgrenciDto>
{
    public override partial CreateUpdateOgrenciDto Map(OgrenciDto source);

    public override partial void Map(OgrenciDto source, CreateUpdateOgrenciDto destination);
}

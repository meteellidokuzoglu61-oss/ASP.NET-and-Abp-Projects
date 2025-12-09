using OkulApplication.Ogretmenler;
using OkulApplication.Ogrenciler;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace OkulApplication;

[Mapper]
public partial class OgrenciToOgrenciDtoMapper : MapperBase<Ogrenci, OgrenciDto>
{
    public override partial OgrenciDto Map(Ogrenci source);

    public override partial void Map(Ogrenci source, OgrenciDto destination);
}

    [Mapper]
public partial class CreateUpdateOgrenciDtoToBookMapper : MapperBase<CreateUpdateOgrenciDto, Ogrenci>
{
    public override partial Ogrenci Map(CreateUpdateOgrenciDto source);

    public override partial void Map(CreateUpdateOgrenciDto source, Ogrenci destination);
}

[Mapper]
public partial class OgretmenToOgretmenDtoMapper : MapperBase<Ogretmen , OgretmenDto>
{
    public override partial  OgretmenDto Map(Ogretmen source);

    public override partial void Map(Ogretmen source, OgretmenDto destination);

}

[Mapper]
public partial class CreateUpdateOgretmenDtoToBookMapper
    : MapperBase<CreateUpdateOgretmenDto, Ogretmen>
{
    public override partial Ogretmen Map(CreateUpdateOgretmenDto source);

    public override partial void Map(CreateUpdateOgretmenDto source, Ogretmen destination);
}

[Mapper]
public partial class OgretmenDtoToCreateUpdateOgretmenDtoMapper
    : MapperBase<OgretmenDto, CreateUpdateOgretmenDto>
{
    public override partial CreateUpdateOgretmenDto Map(OgretmenDto source);
    public override partial void Map(OgretmenDto source, CreateUpdateOgretmenDto destination);
}

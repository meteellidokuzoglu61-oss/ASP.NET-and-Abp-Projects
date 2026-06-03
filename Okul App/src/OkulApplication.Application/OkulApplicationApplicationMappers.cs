using OkulApplication.Ders_Akademik;      
using OkulApplication.Devamsizlik;
using OkulApplication.Duyurular;
using OkulApplication.Mufredatlar;
using OkulApplication.Ogrenci_Belgeler;
using OkulApplication.Ogrenciler;
using OkulApplication.Ogrenciler.Dtos;
using OkulApplication.Ogretmenler;
using OkulApplication.Takvimler;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace OkulApplication;

#region Öğrenci Mapper
[Mapper]
public partial class OgrenciToOgrenciDtoMapper
    : MapperBase<Ogrenci, OgrenciDto>
{
    public override partial OgrenciDto Map(Ogrenci source);
    public override partial void Map(Ogrenci source, OgrenciDto destination);

}

[Mapper]
public partial class CreateUpdateOgrenciDtoToOgrenciMapper
    : MapperBase<CreateUpdateOgrenciDto, Ogrenci>
{
    public override partial Ogrenci Map(CreateUpdateOgrenciDto source);
    public override partial void Map(CreateUpdateOgrenciDto source, Ogrenci destination);
}

#endregion

#region Öğretmen Mapper
[Mapper]
public partial class OgretmenToOgretmenDtoMapper
    : MapperBase<Ogretmen, OgretmenDto>
{
    public override partial OgretmenDto Map(Ogretmen source);
    public override partial void Map(Ogretmen source, OgretmenDto destination);
}

[Mapper]
public partial class CreateUpdateOgretmenDtoToOgretmenMapper
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

[Mapper]

public partial class DerslerToDerslerDtoMapper : 
    MapperBase<Dersler,DerslerDto>
{

    public override partial DerslerDto Map(Dersler source);
    public override partial void Map(Dersler source, DerslerDto destination);



}

[Mapper]
public partial class CreateUpdateDerslerDtoToDerslerMapper
    : MapperBase<CreateUpdateDerslerDto, Dersler>
{
    public override partial Dersler Map(CreateUpdateDerslerDto source);
    public override partial void Map(CreateUpdateDerslerDto source,Dersler destination);
}



#endregion
#region Devamsızlık Mapper

[Mapper]
public partial class DevamsizlikToDevamsizlikDtoMapper
    : MapperBase<DevamsizlikKaydi, DevamsizlikDto>
{
    public override partial DevamsizlikDto Map(DevamsizlikKaydi source);
    public override partial void Map(DevamsizlikKaydi source, DevamsizlikDto destination);
}

[Mapper]
public partial class CreateUpdateDevamsizlikDtoToDevamsizlikMapper
    : MapperBase<CreateUpdateDevamsizlikDto, DevamsizlikKaydi>
{
    public override partial DevamsizlikKaydi Map(CreateUpdateDevamsizlikDto source);
    public override partial void Map(CreateUpdateDevamsizlikDto source, DevamsizlikKaydi destination);
}

#endregion
#region Takvim Mapper


[Mapper]
public partial class TakvimToTakvimDtoMapper
    : MapperBase<Takvim, TakvimDto>
{
    public override partial TakvimDto Map(Takvim source);
    public override partial void Map(Takvim source, TakvimDto destination);
}

[Mapper]
public partial class CreateUpdateTakvimDtoToTakvimMapper
    : MapperBase<CreateUpdateTakvimDto, Takvim>
{
    public override partial Takvim Map(CreateUpdateTakvimDto source);
    public override partial void Map(CreateUpdateTakvimDto source, Takvim destination);
}

#endregion

#region Mufredat Mapper

[Mapper]
public partial class MufredatToMufredatDtoMapper
    : MapperBase<Mufredat, MufredatDto>
{
    public override partial MufredatDto Map(Mufredat source);
    public override partial void Map(Mufredat source, MufredatDto destination);
}

[Mapper]
public partial class CreateUpdateMufredatDtoToMufredatMapper
    : MapperBase<CreateUpdateMufredatDto, Mufredat>
{
    public override partial Mufredat Map(CreateUpdateMufredatDto source);
    public override partial void Map(CreateUpdateMufredatDto source, Mufredat destination);
}
#endregion

#region Duyuru Mapper

[Mapper]
public partial class DuyuruToDuyuruDtoMapper
    : MapperBase<Duyuru, DuyuruDto>
{
    public override partial DuyuruDto Map(Duyuru source);
    public override partial void Map(Duyuru source, DuyuruDto destination);
}

[Mapper]
public partial class CreateUpdateDuyuruDtoToDuyuruMapper
    : MapperBase<CreateUpdateDuyuruDto, Duyuru>
{
    public override partial Duyuru Map(CreateUpdateDuyuruDto source);
    public override partial void Map(CreateUpdateDuyuruDto source, Duyuru destination);
}

#endregion

#region Öğrenci Belge Mapper

[Mapper]
public partial class OgrenciBelgeToOgrenciBelgeDtoMapper
    : MapperBase<OgrenciBelge, OgrenciBelgeDto>
{
    public override partial OgrenciBelgeDto Map(OgrenciBelge source);
    public override partial void Map(OgrenciBelge source, OgrenciBelgeDto destination);
}

[Mapper]
public partial class CreateUpdateOgrenciBelgeDtoToOgrenciBelgeMapper
    : MapperBase<CreateUpdateOgrenciBelgeDto, OgrenciBelge>
{
    public override partial OgrenciBelge Map(CreateUpdateOgrenciBelgeDto source);
    public override partial void Map(CreateUpdateOgrenciBelgeDto source, OgrenciBelge destination);
}

[Mapper]
public partial class OgrenciBelgeDtoToCreateUpdateOgrenciBelgeDtoMapper
    : MapperBase<OgrenciBelgeDto, CreateUpdateOgrenciBelgeDto>
{
    public override partial CreateUpdateOgrenciBelgeDto Map(OgrenciBelgeDto source);
    public override partial void Map(OgrenciBelgeDto source, CreateUpdateOgrenciBelgeDto destination);
}

#endregion

[Mapper]
public partial class OgrenciToOgrenciProfilDtoMapper
    : MapperBase<OgrenciProfilDto, Ogrenci>
{
    public override partial Ogrenci Map(OgrenciProfilDto source);
    public override partial void Map(OgrenciProfilDto source, Ogrenci destination);
}
using OkulApplication.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using static OkulApplication.Permissions.OkulApplicationPermissions;

namespace OkulApplication.Permissions;

public class OkulApplicationPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var okulApplicationGroup = context.AddGroup(
            OkulApplicationPermissions.GroupName,
            L("Permission:OkulApplication")
        );

        // Dashboard
        okulApplicationGroup.AddPermission(
            OkulApplicationPermissions.Dashboard.Host,
            L("Permission:Dashboard"),
            MultiTenancySides.Host
        );
        okulApplicationGroup.AddPermission(
            OkulApplicationPermissions.Dashboard.Tenant,
            L("Permission:Dashboard"),
            MultiTenancySides.Tenant
        );

        // Öğrenciler
        var ogrenciler = okulApplicationGroup.AddPermission(
            OkulApplicationPermissions.Ogrenciler.Default,
            L("Permission:Ogrenciler")
        );
        ogrenciler.AddChild(OkulApplicationPermissions.Ogrenciler.Create, L("Permission:Ogrenciler.Create"));
        ogrenciler.AddChild(OkulApplicationPermissions.Ogrenciler.Edit, L("Permission:Ogrenciler.Edit"));
        ogrenciler.AddChild(OkulApplicationPermissions.Ogrenciler.Delete, L("Permission:Ogrenciler.Delete"));

        var devamsizlik = okulApplicationGroup.AddPermission(
            OkulApplicationPermissions.Devamsizlik.Default,
            L("Permission:Devamsizlik")
        );
        devamsizlik.AddChild(OkulApplicationPermissions.Devamsizlik.Create, L("Permission:Devamsizlik.Create"));
        devamsizlik.AddChild(OkulApplicationPermissions.Devamsizlik.Update, L("Permission:Devamsizlik.Edit"));
        devamsizlik.AddChild(OkulApplicationPermissions.Devamsizlik.Delete, L("Permission:Devamsizlik.Delete"));


        // Öğretmenler
        var ogretmenler = okulApplicationGroup.AddPermission(
            OkulApplicationPermissions.Ogretmenler.Default,
            L("Permission:Ogretmenler")
        );
        ogretmenler.AddChild(OkulApplicationPermissions.Ogretmenler.Create, L("Permission:Ogretmenler.Create"));
        ogretmenler.AddChild(OkulApplicationPermissions.Ogretmenler.Edit, L("Permission:Ogretmenler.Edit"));
        ogretmenler.AddChild(OkulApplicationPermissions.Ogretmenler.Delete, L("Permission:Ogretmenler.Delete"));

        // Akademik izinleri buraya ekleniyor
        var akademik = okulApplicationGroup.AddPermission(
            OkulApplicationPermissions.Akademik.Default,
            L("Permission:Akademik")
        );

        akademik.AddChild(OkulApplicationPermissions.Akademik.Dersler, L("Permission:Akademik.Dersler"));
        akademik.AddChild(OkulApplicationPermissions.Akademik.Mufredat, L("Permission:Akademik.Mufredat"));
        akademik.AddChild(OkulApplicationPermissions.Akademik.Notlar, L("Permission:Akademik.Notlar"));
        akademik.AddChild(OkulApplicationPermissions.Akademik.Ortalama, L("Permission:Akademik.Ortalama"));
        akademik.AddChild(OkulApplicationPermissions.Akademik.Karne, L("Permission:Akademik.Karne"));
        akademik.AddChild(OkulApplicationPermissions.Akademik.Takvim, L("Permission:Akademik.Takvim"));


        var ogrenciBelge = okulApplicationGroup.AddPermission(

            OkulApplicationPermissions.Belgeler.Default,
            L("Permission:Belgeler")


            );

        ogrenciBelge.AddChild(OkulApplicationPermissions.Belgeler.Create, L("Permission:Belgeler.Create"));
        ogrenciBelge.AddChild(OkulApplicationPermissions.Belgeler.Edit, L("Permission:Belgeler.Edit"));
        ogrenciBelge.AddChild(OkulApplicationPermissions.Belgeler.Delete, L("Permission:Belgeler.Delete"));

    }




    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<OkulApplicationResource>(name);
    }
}

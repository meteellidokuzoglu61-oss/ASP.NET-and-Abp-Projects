using OkulApplication.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

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

        var ogretmenler = okulApplicationGroup.AddPermission(
    OkulApplicationPermissions.Ogretmenler.Default,
    L("Permission:Ogretmenler")
);
        ogretmenler.AddChild(OkulApplicationPermissions.Ogretmenler.Create, L("Permission:Ogretmenler.Create"));
        ogretmenler.AddChild(OkulApplicationPermissions.Ogretmenler.Edit, L("Permission:Ogretmenler.Edit"));
        ogretmenler.AddChild(OkulApplicationPermissions.Ogretmenler.Delete, L("Permission:Ogretmenler.Delete"));
    }
    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<OkulApplicationResource>(name);
    }
}

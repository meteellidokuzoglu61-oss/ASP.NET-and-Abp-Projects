using Microsoft.Extensions.DependencyInjection;
using OkulApplication.Ders_Akademik;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Mapperly;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace OkulApplication;

[DependsOn(
    typeof(OkulApplicationDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(OkulApplicationApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class OkulApplicationApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMapperlyObjectMapper<OkulApplicationApplicationModule>();
    }

}

using Volo.Abp.Modularity;

namespace OkulApplication;

[DependsOn(
    typeof(OkulApplicationDomainModule),
    typeof(OkulApplicationTestBaseModule)
)]
public class OkulApplicationDomainTestModule : AbpModule
{

}

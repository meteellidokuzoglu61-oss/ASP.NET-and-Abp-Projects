using Volo.Abp.Modularity;

namespace OkulApplication;

[DependsOn(
    typeof(OkulApplicationApplicationModule),
    typeof(OkulApplicationDomainTestModule)
)]
public class OkulApplicationApplicationTestModule : AbpModule
{

}

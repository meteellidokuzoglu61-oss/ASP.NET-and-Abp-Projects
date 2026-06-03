using OkulApplication.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace OkulApplication.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(OkulApplicationEntityFrameworkCoreModule),
    typeof(OkulApplicationApplicationContractsModule)
    )]
public class OkulApplicationDbMigratorModule : AbpModule
{
}

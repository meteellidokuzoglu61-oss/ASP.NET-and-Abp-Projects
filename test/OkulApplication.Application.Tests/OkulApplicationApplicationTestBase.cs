using Volo.Abp.Modularity;

namespace OkulApplication;

public abstract class OkulApplicationApplicationTestBase<TStartupModule> : OkulApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

using Volo.Abp.Modularity;

namespace OkulApplication;

/* Inherit from this class for your domain layer tests. */
public abstract class OkulApplicationDomainTestBase<TStartupModule> : OkulApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

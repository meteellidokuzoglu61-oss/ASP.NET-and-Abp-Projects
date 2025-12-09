using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace OkulApplication.Data;

/* This is used if database provider does't define
 * IOkulApplicationDbSchemaMigrator implementation.
 */
public class NullOkulApplicationDbSchemaMigrator : IOkulApplicationDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

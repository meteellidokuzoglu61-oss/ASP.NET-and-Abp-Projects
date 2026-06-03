using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OkulApplication.Data;
using Volo.Abp.DependencyInjection;

namespace OkulApplication.EntityFrameworkCore;

public class EntityFrameworkCoreOkulApplicationDbSchemaMigrator
    : IOkulApplicationDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreOkulApplicationDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the OkulApplicationDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<OkulApplicationDbContext>()
            .Database
            .MigrateAsync();
    }
}

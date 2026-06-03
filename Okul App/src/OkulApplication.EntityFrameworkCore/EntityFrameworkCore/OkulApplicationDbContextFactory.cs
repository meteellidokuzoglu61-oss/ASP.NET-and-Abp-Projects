using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OkulApplication.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class OkulApplicationDbContextFactory : IDesignTimeDbContextFactory<OkulApplicationDbContext>
{
    public OkulApplicationDbContext CreateDbContext(string[] args)
    {
        // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        OkulApplicationEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<OkulApplicationDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default"));

        return new OkulApplicationDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../OkulApplication.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}

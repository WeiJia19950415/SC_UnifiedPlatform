using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SC_UnifiedPlatform.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class SC_UnifiedPlatformDbContextFactory : IDesignTimeDbContextFactory<SC_UnifiedPlatformDbContext>
{
    public SC_UnifiedPlatformDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        SC_UnifiedPlatformEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<SC_UnifiedPlatformDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new SC_UnifiedPlatformDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SC_UnifiedPlatform.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables();

        return builder.Build();
    }
}

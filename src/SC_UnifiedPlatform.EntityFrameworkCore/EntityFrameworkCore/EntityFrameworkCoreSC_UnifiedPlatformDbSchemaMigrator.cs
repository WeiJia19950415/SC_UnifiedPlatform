using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SC_UnifiedPlatform.Data;
using Volo.Abp.DependencyInjection;

namespace SC_UnifiedPlatform.EntityFrameworkCore;

public class EntityFrameworkCoreSC_UnifiedPlatformDbSchemaMigrator
    : ISC_UnifiedPlatformDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSC_UnifiedPlatformDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the SC_UnifiedPlatformDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SC_UnifiedPlatformDbContext>()
            .Database
            .MigrateAsync();
    }
}

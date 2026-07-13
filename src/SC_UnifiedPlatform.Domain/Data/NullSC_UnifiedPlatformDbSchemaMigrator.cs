using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SC_UnifiedPlatform.Data;

/* This is used if database provider does't define
 * ISC_UnifiedPlatformDbSchemaMigrator implementation.
 */
public class NullSC_UnifiedPlatformDbSchemaMigrator : ISC_UnifiedPlatformDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

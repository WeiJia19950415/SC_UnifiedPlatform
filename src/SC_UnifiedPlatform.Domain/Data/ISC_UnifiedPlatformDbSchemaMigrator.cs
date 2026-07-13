using System.Threading.Tasks;

namespace SC_UnifiedPlatform.Data;

public interface ISC_UnifiedPlatformDbSchemaMigrator
{
    Task MigrateAsync();
}

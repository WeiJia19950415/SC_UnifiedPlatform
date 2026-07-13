using SC_UnifiedPlatform.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SC_UnifiedPlatform.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SC_UnifiedPlatformEntityFrameworkCoreModule),
    typeof(SC_UnifiedPlatformApplicationContractsModule)
)]
public class SC_UnifiedPlatformDbMigratorModule : AbpModule
{
}

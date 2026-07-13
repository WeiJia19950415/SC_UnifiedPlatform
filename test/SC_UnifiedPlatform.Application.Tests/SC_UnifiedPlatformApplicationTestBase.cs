using Volo.Abp.Modularity;

namespace SC_UnifiedPlatform;

public abstract class SC_UnifiedPlatformApplicationTestBase<TStartupModule> : SC_UnifiedPlatformTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

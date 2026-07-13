using Volo.Abp.Modularity;

namespace SC_UnifiedPlatform;

/* Inherit from this class for your domain layer tests. */
public abstract class SC_UnifiedPlatformDomainTestBase<TStartupModule> : SC_UnifiedPlatformTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

using Volo.Abp.Modularity;

namespace SC_UnifiedPlatform;

[DependsOn(
    typeof(SC_UnifiedPlatformDomainModule),
    typeof(SC_UnifiedPlatformTestBaseModule)
)]
public class SC_UnifiedPlatformDomainTestModule : AbpModule
{

}

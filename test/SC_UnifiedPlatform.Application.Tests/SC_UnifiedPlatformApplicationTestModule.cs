using Volo.Abp.Modularity;

namespace SC_UnifiedPlatform;

[DependsOn(
    typeof(SC_UnifiedPlatformApplicationModule),
    typeof(SC_UnifiedPlatformDomainTestModule)
)]
public class SC_UnifiedPlatformApplicationTestModule : AbpModule
{

}

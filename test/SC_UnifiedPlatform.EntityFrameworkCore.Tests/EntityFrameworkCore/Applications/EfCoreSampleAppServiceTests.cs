using SC_UnifiedPlatform.Samples;
using Xunit;

namespace SC_UnifiedPlatform.EntityFrameworkCore.Applications;

[Collection(SC_UnifiedPlatformTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<SC_UnifiedPlatformEntityFrameworkCoreTestModule>
{

}

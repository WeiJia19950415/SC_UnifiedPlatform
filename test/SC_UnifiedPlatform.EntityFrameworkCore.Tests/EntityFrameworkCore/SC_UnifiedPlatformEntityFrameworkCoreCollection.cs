using Xunit;

namespace SC_UnifiedPlatform.EntityFrameworkCore;

[CollectionDefinition(SC_UnifiedPlatformTestConsts.CollectionDefinitionName)]
public class SC_UnifiedPlatformEntityFrameworkCoreCollection : ICollectionFixture<SC_UnifiedPlatformEntityFrameworkCoreFixture>
{

}

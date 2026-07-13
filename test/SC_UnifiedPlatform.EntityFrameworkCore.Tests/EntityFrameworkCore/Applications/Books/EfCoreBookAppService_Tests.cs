using SC_UnifiedPlatform.Books;
using Xunit;

namespace SC_UnifiedPlatform.EntityFrameworkCore.Applications.Books;

[Collection(SC_UnifiedPlatformTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<SC_UnifiedPlatformEntityFrameworkCoreTestModule>
{

}
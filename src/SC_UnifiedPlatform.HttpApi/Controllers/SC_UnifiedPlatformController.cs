using SC_UnifiedPlatform.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SC_UnifiedPlatform.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SC_UnifiedPlatformController : AbpControllerBase
{
    protected SC_UnifiedPlatformController()
    {
        LocalizationResource = typeof(SC_UnifiedPlatformResource);
    }
}

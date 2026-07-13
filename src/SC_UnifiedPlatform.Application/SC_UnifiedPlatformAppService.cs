using SC_UnifiedPlatform.Localization;
using Volo.Abp.Application.Services;

namespace SC_UnifiedPlatform;

/* Inherit your application services from this class.
 */
public abstract class SC_UnifiedPlatformAppService : ApplicationService
{
    protected SC_UnifiedPlatformAppService()
    {
        LocalizationResource = typeof(SC_UnifiedPlatformResource);
    }
}

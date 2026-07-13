using Microsoft.Extensions.Localization;
using SC_UnifiedPlatform.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SC_UnifiedPlatform;

[Dependency(ReplaceServices = true)]
public class SC_UnifiedPlatformBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<SC_UnifiedPlatformResource> _localizer;

    public SC_UnifiedPlatformBrandingProvider(IStringLocalizer<SC_UnifiedPlatformResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}

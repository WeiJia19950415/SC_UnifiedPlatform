using Microsoft.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace SC_UnifiedPlatform.EntityFrameworkCore;

public static class SC_UnifiedPlatformEfCoreEntityExtensionMappings
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        SC_UnifiedPlatformGlobalFeatureConfigurator.Configure();
        SC_UnifiedPlatformModuleExtensionConfigurator.Configure();

        OneTimeRunner.Run(() =>
        {
            ObjectExtensionManager.Instance
             .MapEfCoreProperty<IdentityUser, string>(
                 "IMCode",
                 (entityBuilder, propertyBuilder) =>
                 {
                     propertyBuilder.HasMaxLength(128);
                 }
             )
             .MapEfCoreProperty<IdentityUser, bool>(
                 "IsFirstLogin",
                 (entityBuilder, propertyBuilder) =>
                 {
                     propertyBuilder.HasDefaultValue(true);
                 }
             );
        });
    }
}

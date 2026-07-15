using System.ComponentModel.DataAnnotations;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace SC_UnifiedPlatform;

public static class SC_UnifiedPlatformModuleExtensionConfigurator
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        OneTimeRunner.Run(() =>
        {
            ConfigureExistingProperties();
            ConfigureExtraProperties();
        });
    }

    private static void ConfigureExistingProperties()
    {
        /* You can change max lengths for properties of the
         * entities defined in the modules used by your application.
         *
         * Example: Change user and role name max lengths

           AbpUserConsts.MaxNameLength = 99;
           IdentityRoleConsts.MaxNameLength = 99;

         * Notice: It is not suggested to change property lengths
         * unless you really need it. Go with the standard values wherever possible.
         *
         * If you are using EF Core, you will need to run the add-migration command after your changes.
         */
    }

    private static void ConfigureExtraProperties()
    {
        ObjectExtensionManager.Instance.Modules()
                    .ConfigureIdentity(identity =>
                    {
                        identity.ConfigureUser(user =>
                        {
                            // 1. 新增 IMCode 字段
                            user.AddOrUpdateProperty<string>(
                                "IMCode",
                                property =>
                                {
                                    property.Attributes.Add(new StringLengthAttribute(128));
                                }
                            );

                            // 2. 新增验证是否为初次登录的字段 (默认为 true)
                            user.AddOrUpdateProperty<bool>(
                                "IsFirstLogin",
                                property =>
                                {
                                    property.DefaultValue = true;
                                }
                            );
                        });
                    });
    }
}

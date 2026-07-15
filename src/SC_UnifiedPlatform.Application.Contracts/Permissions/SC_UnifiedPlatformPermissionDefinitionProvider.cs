using SC_UnifiedPlatform.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace SC_UnifiedPlatform.Permissions;

public class SC_UnifiedPlatformPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SC_UnifiedPlatformPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(SC_UnifiedPlatformPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(SC_UnifiedPlatformPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(SC_UnifiedPlatformPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(SC_UnifiedPlatformPermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SC_UnifiedPlatformPermissions.MyPermission1, L("Permission:MyPermission1"));

        // 注册认证与登录权限
        var authPermission = myGroup.AddPermission(SC_UnifiedPlatformPermissions.Auth.Default, L("Permission:Auth"));
        authPermission.AddChild(SC_UnifiedPlatformPermissions.Auth.Login, L("Permission:Auth.Login"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SC_UnifiedPlatformResource>(name);
    }
}

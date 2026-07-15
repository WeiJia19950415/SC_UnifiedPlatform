namespace SC_UnifiedPlatform.Permissions;

public static class SC_UnifiedPlatformPermissions
{
    public const string GroupName = "SC_UnifiedPlatform";


    public static class Books
    {
        public const string Default = GroupName + ".Books";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    // 新增 Auth 权限组定义
    public static class Auth
    {
        public const string Default = GroupName + ".Auth";
        public const string Login = Default + ".Login";
    }


}

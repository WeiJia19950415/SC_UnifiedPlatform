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
    
    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
}

namespace OkulApplication.Permissions
{
    public static class OkulApplicationPermissions
    {
        public const string GroupName = "OkulApplication";

        public static class Dashboard
        {
            public const string Default = GroupName + ".Dashboard";
            public const string Host = Default + ".Host";
            public const string Tenant = Default + ".Tenant";
        }

        public static class Ogrenciler
        {
            public const string Default = GroupName + ".Ogrenciler";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}

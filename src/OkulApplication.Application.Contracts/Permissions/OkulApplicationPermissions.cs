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

        public static class Ogretmenler
        {
            public const string Default = GroupName + ".Ogretmenler";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

        public static class Akademik
        {
            public const string Default = GroupName + ".Akademik";
            public const string Dersler = Default + ".Dersler";
            public const string Mufredat = Default + ".Mufredat";
            public const string Notlar = Default + ".Notlar";
            public const string Ortalama = Default + ".Ortalama";
            public const string Karne = Default + ".Karne";
            public const string Takvim = Default + ".Takvim";
        }

        // ✅ DEVAMSIZLIK (DÜZGÜN)
        public static class Devamsizlik
        {
            public const string Default = GroupName + ".Devamsizlik";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class Etkinlik
        {
            public const string Default = GroupName;
            public const string Create = GroupName + ".Create";
            public const string Delete = GroupName + ".Delete";
        }

        public static class Belgeler
        {
            public const string Default = GroupName;
            public const string Create = GroupName + ".Create";
            public const string Edit = GroupName + "Edit";
            public const string Delete = GroupName + ".Delete";
        }
    }
}




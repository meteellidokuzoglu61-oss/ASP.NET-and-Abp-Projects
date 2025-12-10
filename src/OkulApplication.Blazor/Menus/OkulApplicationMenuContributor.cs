using OkulApplication.Localization;
using OkulApplication.MultiTenancy;
using OkulApplication.Permissions;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.UI.Navigation;

namespace OkulApplication.Blazor.Menus
{
    public class OkulApplicationMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var administration = context.Menu.GetAdministration();
            var l = context.GetLocalizer<OkulApplicationResource>();

            // Ana Sayfa
            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    OkulApplicationMenus.Home,
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home",
                    order: 0
                )
            );

            // Students Menüsü
            var studentsMenu = new ApplicationMenuItem(
                "StudentsMenu",
                l["Menu:Students"],
                icon: "fa fa-user"
            );

            studentsMenu.AddItem(
                new ApplicationMenuItem(
                    "StudentsMenu.List",
                    l["Menu:Students"],
                    url: "/students"
                ).RequirePermissions(OkulApplicationPermissions.Ogrenciler.Default)
            );

            context.Menu.AddItem(studentsMenu);

            // Teachers Menüsü örnek
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    "TeacherApp",
                    l["Menu:TeachersApp"],
                    icon: "fa fa-chalkboard-teacher"
                ).AddItem(
                    new ApplicationMenuItem(
                        "TeacherApp.Teacher",
                        l["Menu:Teachers"],
                        url: "/teachers"
                    ).RequirePermissions(OkulApplicationPermissions.Ogretmenler.Default)
                )
            );

            // Yönetim menüleri
            if (MultiTenancyConsts.IsEnabled)
            {
                administration.SetSubItemOrder("AbpTenantManagement", 1);
            }
            administration.SetSubItemOrder("AbpIdentity", 2);
            administration.SetSubItemOrder("AbpSettingManagement", 3);

            return Task.CompletedTask;
        }
    }
}

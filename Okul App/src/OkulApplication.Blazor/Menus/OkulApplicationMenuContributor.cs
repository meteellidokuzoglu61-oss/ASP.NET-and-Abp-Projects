using Microsoft.Extensions.DependencyInjection;
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

        private async Task<Task> ConfigureMainMenuAsync(MenuConfigurationContext context)
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

            context.Menu.AddItem(
    new ApplicationMenuItem(
        "Belgeler",
        "Belgeler",
        icon: "fa fa-folder"
    ).AddItem(
        new ApplicationMenuItem(
            "OgrenciBelgeleri",
            "Öğrenci Belgeleri",
            "/belgeler/ogrenci",
            icon: "fa fa-file"
        )
    ).RequirePermissions(OkulApplicationPermissions.Ogrenciler.Default)
);
            context.Menu.AddItem(
    new ApplicationMenuItem(
        "Nobet",
        l["Nöbet & Görev Takibi"],
        url: "/nobet",
        icon: "fas fa-user-clock"
    )
);           context.Menu.AddItem(
            new ApplicationMenuItem(
                "Profil",
                l["Profilim"],
                url: "/profilim",
                icon: "fas fa-user"



            )
          );


            if (await context.IsGrantedAsync(OkulApplicationPermissions.Akademik.Default))
            {
                var akademikMenu = new ApplicationMenuItem(
                    "Akademik",
                    l["Menu:Akademik"],
                    icon: "fa fa-graduation-cap"
                );

                akademikMenu.AddItem(new ApplicationMenuItem(
                    "Dersler",
                    l["Menu:Dersler"],
                    "/dersler",
                    requiredPermissionName: OkulApplicationPermissions.Akademik.Dersler
                ));

                akademikMenu.AddItem(new ApplicationMenuItem(
                    "Mufredat",
                    l["Menu:Mufredat"],
                    "/Akademik/Mufredat",
                    requiredPermissionName: OkulApplicationPermissions.Akademik.Mufredat
                ));

                akademikMenu.AddItem(new ApplicationMenuItem(
                        "Akademik.TopluNotGiris",
        "Not İşlemleri",
        url: "/toplu-not-giris",
                    requiredPermissionName: OkulApplicationPermissions.Akademik.Notlar
                ));

                akademikMenu.AddItem(new ApplicationMenuItem(
                    "Ortalama",
                    l["Menu:Ortalama"],
                    "/Akademik/Ortalama",
                    requiredPermissionName: OkulApplicationPermissions.Akademik.Ortalama
                ));

                akademikMenu.AddItem(new ApplicationMenuItem(
                    "Karne",
                    l["Menu:Karne"],
                    "/Akademik/Karne",
                    requiredPermissionName: OkulApplicationPermissions.Akademik.Karne
                ));

                akademikMenu.AddItem(new ApplicationMenuItem(
                    "Takvim",
                    l["Menu:Takvim"],
                    "/Akademik/Takvim",
                    requiredPermissionName: OkulApplicationPermissions.Akademik.Takvim
                ));

                context.Menu.AddItem(
    new ApplicationMenuItem(
        "DilekceIslemleri",
        l["Dilekçe İşlemleri"],
        url: "/dilekce",
        icon: "fas fa-file-signature"
    )
);
                context.Menu.AddItem(
new ApplicationMenuItem(
"DisiplinIslemleri",
l["Disiplin İşlemleri"],
url: "/disiplin",
icon: "fas fa-file-signature"
)
);
                context.Menu.AddItem(
     new ApplicationMenuItem(
     "OgrenciSicil",
     l["Öğrenci Sicil"],
     url: "/ogrenci-sicil",
     icon: "fas fa-file-signature"
     )
     );



                context.Menu.AddItem(akademikMenu);
            }

            await Task.CompletedTask;

            context.Menu.AddItem(
      new ApplicationMenuItem(
          "Alanlar",
          l["Alanlar"],
          url: "/alanlar",
          icon: "fas fa - list - ul"
        ));
     



            var permissionChecker =
                context.ServiceProvider.GetRequiredService<IPermissionChecker>();

            if (await permissionChecker.IsGrantedAsync(
    OkulApplicationPermissions.Devamsizlik.Default))
{
    context.Menu.AddItem(
        new ApplicationMenuItem(
            "Devamsizlik",
            l["Menu:Devamsizlik"],
            url: "/devamsizlik",
            icon: "fas fa-user-check"
        )
    );
}





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
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    "Hakkimizda",
                     l["Hakkımızda"],
                url: "/hakkimizda"

                )
            );

            context.Menu.AddItem(
              new ApplicationMenuItem(
                  "Duyuru",
                   l["Duyurular"],
              url: "/duyurular"

              )
          );






            context.Menu.AddItem(
    new ApplicationMenuItem(
        "KadromuzMenu",
        l["Menu:Kadromuz"],
        url: "/kadromuz",
        icon: "fa fa-users"
    )
);
            context.Menu.AddItem(
                  new ApplicationMenuItem(
                      "Adresler",
                      "Adres Bilgileri",
                      "/adresler", // Blazor sayfa route
                      icon: "fas fa-map-marker-alt"
                      )
                  );

            context.Menu.AddItem(
                  new ApplicationMenuItem(
                      "Öğrenci Not Raporu",
                      "Not Bilgileri",
                     "/ogrenci-not-rapor", // Blazor sayfa route
                      icon: "fas fa-map-marker-alt"
                      )
                  );



            var notMenu = new ApplicationMenuItem(
    "TopluNotGiris",
    l["Menu:TopluNotGiris"],
    icon: "fa fa-edit",
    url: "/toplu-not-giris"
    );
            context.Menu.AddItem(notMenu);


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

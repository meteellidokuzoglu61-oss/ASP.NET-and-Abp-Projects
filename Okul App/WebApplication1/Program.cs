using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OgrenciApp.Data;
using OgrenciApp.Models;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// DbContext ve Identity
builder.Services.AddDbContext<OgrenciContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<OgrenciContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// ---------------- Seed Data ----------------
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<OgrenciContext>();

    // Bölüm ve sınıfları ekle
    if (!context.Bolumler.Any())
    {
        var bolum = new Bolum
        {
            Bolum_Ad = "Bilişim Teknolojileri",
            KayitDonemi = "2025-2026 Güz Dönemi",
            Sinif = new List<Sinif>
            {
                new Sinif { Sinif_Ad = "9.Sınıf", ToplamKontenjan=60, Dolu=28, ProgramTipi="AMP" },
                new Sinif { Sinif_Ad = "10.Sınıf", ToplamKontenjan=60, Dolu=25, ProgramTipi="ATP" },
                new Sinif { Sinif_Ad = "11.Sınıf", ToplamKontenjan=60, Dolu=27, ProgramTipi="AMP" },
                new Sinif { Sinif_Ad = "12.Sınıf", ToplamKontenjan=60, Dolu=27, ProgramTipi="AMP" }
            }
        };

        context.Bolumler.Add(bolum);
        context.SaveChanges();
    }
    // Role/User seed
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    var adminUser = await userManager.FindByNameAsync("admin");
    if (adminUser == null)
    {
        adminUser = new IdentityUser
        {
            UserName = "admin",
            Email = "admin@example.com"
        };

        await userManager.CreateAsync(adminUser, "Admin123*");
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}
// ------------------------------------------

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

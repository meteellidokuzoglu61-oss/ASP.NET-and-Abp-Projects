using Microsoft.EntityFrameworkCore;
using OkulApplication.Notlar;
using OkulApplication.Ogrenciler;
using OkulApplication.Ogretmenler;
using OkulApplication.Devamsizlik;
using OkulApplication.Takvimler;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using OkulApplication.Mufredatlar;
using OkulApplication.Duyurular;
using OkulApplication.Ogrenci_Belgeler;

namespace OkulApplication.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class OkulApplicationDbContext :
    AbpDbContext<OkulApplicationDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Ogrenci> Ogrenciler { get; set; }
    public DbSet<Ogretmen> Ogretmenler { get; set; }
    public DbSet<Not> Notlar { get; set; }
    public DbSet<Dersler> Dersler { get; set; }
    public DbSet<DevamsizlikKaydi> Devamsizliklar { get; set; }
    public DbSet<Takvim> Takvimler { get; set; }

    public DbSet<Mufredat> Mufredatlar { get; set; }
    public DbSet<Duyuru> Duyurular { get; set; }
    public DbSet<OgrenciBelge> OgrenciBelgeleri { get; set; }


    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public OkulApplicationDbContext(DbContextOptions<OkulApplicationDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();


        builder.Entity<Ogrenci>(b =>
        {
            b.ToTable(OkulApplicationConsts.DbTablePrefix + "Ogrenciler",
                OkulApplicationConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Ogrenci_AdiSoyadi).IsRequired().HasMaxLength(128);
            b.Property(x => x.Ogrenci_Sinifi).IsRequired().HasMaxLength(5);

            b.Property(x => x.Ogrenci_Bolumu)
             .IsRequired()
             .HasConversion<int>();

            b.Property(x => x.Numarasi)
                .IsRequired();

            b.Property(x => x.Email)
                .IsRequired();
        });

        builder.Entity<Ogretmen>(b =>
        {
            b.ToTable("Ogretmenler", OkulApplicationConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Ogretmen_AdiSoyadi).IsRequired().HasMaxLength(128);
            b.Property(x => x.Ogretmen_BabaAdi)
               .IsRequired(false)  // nullable
               .HasMaxLength(128);

            b.Property(x => x.Ogretmen_Bransi)
                   .IsRequired();

            b.Property(x => x.Ogretmen_Sinif)
                   .IsRequired();

            b.Property(x => x.Ogretmen_Sube)
                   .IsRequired()
                   .HasMaxLength(5);

            b.Property(x => x.Ogretmen_DogumTarhi)
                   .IsRequired();

            b.Property(x => x.Unvan)
                .HasMaxLength(128)
                .IsRequired(false);

        });

        builder.Entity<Not>(b =>
        {
            b.ToTable(OkulApplicationConsts.DbTablePrefix + "Notlar",
                OkulApplicationConsts.DbSchema);

            b.ConfigureByConvention();

            b.Property(x => x.Ders).IsRequired();
            b.Property(x => x.Sozlu).IsRequired();
            b.Property(x => x.Yazili).IsRequired();
            b.Property(x => x.Proje).IsRequired();
        });



        builder.Entity<Dersler>(b =>
        {
            b.ToTable(OkulApplicationConsts.DbTablePrefix + "Dersler",
             OkulApplicationConsts.DbSchema);

            b.ConfigureByConvention();
            b.Property(x => x.Ad);
            b.Property(x => x.Kodu);
            b.Property(x => x.Kredi);
        });

        builder.Entity<DevamsizlikKaydi>(b =>
        {
            // Tablo adı ve schema
            b.ToTable(OkulApplicationConsts.DbTablePrefix + "Devamsizlik",
                      OkulApplicationConsts.DbSchema);

            // ABP konvansiyonları (Id, audit alanları vs.)
            b.ConfigureByConvention();

            // Alanlar
            b.Property(x => x.OgrenciId).IsRequired();
            b.Property(x => x.Devamsizlik_Tarihi).IsRequired();
            b.Property(x => x.Tip).IsRequired();

        });

        builder.Entity<Takvim>(b =>
        {
            b.ToTable("Takvimler");

            b.ConfigureByConvention(); // ABP için önemli

            b.Property(x => x.Baslik)
             .IsRequired()
             .HasMaxLength(128);

            b.Property(x => x.BaslangicTarihi).IsRequired();
            b.Property(x => x.BitisTarihi).IsRequired();

            b.Property(x => x.Tip)
     .IsRequired();

            // ✅ Nullable Guid – opsiyonel
            b.Property(x => x.DersId)
             .IsRequired(false);
        });

        builder.Entity<Mufredat>(b =>
        {
            b.ToTable("Mufredatlar");
            b.ConfigureByConvention();
        });

        builder.Entity<Duyuru>(b =>
        {
            b.ToTable("Duyurular");
            b.ConfigureByConvention();
            b.Property(x => x.Baslik)
            .IsRequired().HasMaxLength(128);
            b.Property(x => x.Icerik)
            .IsRequired().HasMaxLength(128);
            b.Property(x => x.YayimTarihi)
            .IsRequired().HasMaxLength(128);


        });

        builder.Entity<OgrenciBelge> (b =>
        {
            b.ToTable(OkulApplicationConsts.DbTablePrefix + "OgrenciBelgeleri",
                      OkulApplicationConsts.DbSchema);

            b.ConfigureByConvention();

            // Alanlar
            b.Property(x => x.OgrenciId).IsRequired();
            b.Property(x => x.BelgeAdi).IsRequired();
            b.Property(x => x.DosyaYolu).IsRequired();
            b.Property(x => x.DosyaTuru).IsRequired();
            b.Property(x => x.YuklemeTarihi).IsRequired();
            b.Property(x => x.Aktif).IsRequired();





        });
    }
}

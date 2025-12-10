using Microsoft.EntityFrameworkCore;
using OkulApplication.Notlar;
using OkulApplication.Ogrenciler;
using OkulApplication.Ogretmenler;
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
  public  DbSet<Ogrenci>Ogrenciler {  get; set; }
  public DbSet<Ogretmen>Ogretmenler { get; set; }
  public DbSet<Not>Notlar {  get; set; }

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

        });

        builder.Entity<Not>(b =>
        {
            b.ToTable(OkulApplicationConsts.DbTablePrefix + "Notlar",
                OkulApplicationConsts.DbSchema);

            b.ConfigureByConvention(); // Id, CreationTime, etc.

            // optional: öğretmene bağlamak istiyorsan uncomment et
            // b.Property(x => x.OgretmenId).IsRequired();

            // Not kolonları
            b.Property(x => x.Sozlu).IsRequired();
            b.Property(x => x.Yazili).IsRequired();
            b.Property(x => x.Proje).IsRequired();
        });



    }
}

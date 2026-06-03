using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.SqlServer;
using OgrenciApp.Models;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using WebApplication1.Models;


namespace OgrenciApp.Data
{
    public class OgrenciContext : IdentityDbContext
    {
        public OgrenciContext(DbContextOptions<OgrenciContext> options) : base(options) { }



        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Ogrenci> Ogrenciler { get; set; }

        public DbSet<DersProgrami> DersProgramilari { get; set; }

        public DbSet<Duyuru> Duyurular { get; set; }

        public DbSet<Ogretmen> Ogretmenler { get; set; }

        public DbSet<Etkinlik> Etkinlikler { get; set; }

        public DbSet<Sinav> Sinavlar { get; set; }

        public DbSet<Bolum> Bolumler { get; set; }

        public DbSet<Sinif> Sinif { get; set; }

        public DbSet<Devamsizlik>Devamsizliklar { get; set; }
        public DbSet<Not> Notlar { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<Bildirim> Bildirimler { get; set; }



        public object Departments { get; internal set; }


        
    }
 }

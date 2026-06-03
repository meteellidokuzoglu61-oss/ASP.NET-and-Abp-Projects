using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace OkulApplication.Notlar
{
    public class Not : Entity<Guid>
    {

        public string Ogrenci_AdiSoyadi {  get; set; }
        public string Ders { get; set; } // Branş
        [Range(0, 100, ErrorMessage = "0 – 100 arası giriniz")]
        public decimal Sozlu { get; set; } // 0-100
        [Range(0, 100, ErrorMessage = "0 – 100 arası giriniz")]

        public decimal Yazili { get; set; } // 0-100
        [Range(0, 100, ErrorMessage = "0 – 100 arası giriniz")]

        public decimal Proje { get; set; } // 0-100

        public decimal Ortalama { get; set; }
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
    }
}

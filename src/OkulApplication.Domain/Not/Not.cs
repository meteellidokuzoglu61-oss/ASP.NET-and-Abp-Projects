using System;
using Volo.Abp.Domain.Entities;

namespace OkulApplication.Notlar
{
    public class Not : Entity<Guid>
    {
      
        public string Ders { get; set; } // Branş
        public decimal Sozlu { get; set; } // 0-100
        public decimal Yazili { get; set; } // 0-100
        public decimal Proje { get; set; } // 0-100
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
    }
}

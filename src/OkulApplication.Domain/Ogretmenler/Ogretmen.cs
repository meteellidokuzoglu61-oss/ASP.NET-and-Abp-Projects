using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace OkulApplication.Ogretmenler
{
    [Table("Ogretmenler")]
    public class Ogretmen : AuditedAggregateRoot<Guid>
    {
        public string Ogretmen_AdiSoyadi {  get; set; }
        public DateTime Ogretmen_DogumTarhi { get; set; }
        public string Ogretmen_BabaAdi { get; set; }

        public Branslar Ogretmen_Bransi { get; set; }
        
        public int Ogretmen_Sinif {  get; set; }
        public string Ogretmen_Sube { get; set; }










    }
}

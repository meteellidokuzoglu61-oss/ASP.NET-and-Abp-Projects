using OgrenciApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OgrenciApp.Models
{
    public class Sinif
    {
        [Key]
        public int Id { get; set; }
        public string Sinif_Ad { get; set; } // Örn: 10-A, 11-B
        public int ToplamKontenjan { get; set; }
        public int Dolu { get; set; }
        public string ProgramTipi { get; set; } // AMP veya ATP

        public string Sube {  get; set; }


        [NotMapped]
        public int Bos => ToplamKontenjan - Dolu;

        // Foreign key
        public int BolumId { get; set; }
        public Bolum Bolum_Ad { get; set; }


        public ICollection<Ogrenci> Ogrenciler { get; set; }

    }
}

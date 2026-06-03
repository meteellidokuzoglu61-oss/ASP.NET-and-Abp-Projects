using System;
using System.ComponentModel.DataAnnotations;


namespace OkulApplication.Duyurular
{
    public class CreateUpdateDuyuruDto
    {

        [Required]
        [StringLength(200)]
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime YayimTarihi { get; set; }

    }
}

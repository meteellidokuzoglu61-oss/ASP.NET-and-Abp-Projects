using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Models
{
    public class Kullanici
    {
        [Key]
        public int Id { get; set; }
        public string Kullanici_Adi { get; set; }
        public string Kullanici_Sifresi { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OgrenciApp.Models;

namespace WebApplication1.Models
{
    [Table("Etkinlikler", Schema = "dbo")]
    public class Etkinlik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Etkinlik adı zorunludur.")]
        [StringLength(100)]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Tarih zorunludur.")]
        public DateTime Tarih { get; set; }

        [StringLength(500)]
        public string? Aciklama { get; set; }
    }














}
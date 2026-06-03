using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OkulApplication.Devamsizlik
{
    public class CreateUpdateDevamsizlikDto
    {
        [Required]
        public Guid OgrenciId { get; set; }
        [Required]
        public DateTime Devamsizlik_Tarihi { get; set; }
        [Required]
        public Devamsizlik_Tipi Tip { get; set; }

    }
}

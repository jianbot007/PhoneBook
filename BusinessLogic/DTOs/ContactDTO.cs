using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class ContactDTO
    {
        public int id { get; set; }
        public int user_id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string Groups { get; set; }
        public string PhotoPath { get; set; }
        [Required]
        [StringLength(200)]
        public string Address { get; set; }
    }
}

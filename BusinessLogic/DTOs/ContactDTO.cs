using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class ContactDTO
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Groups { get; set; }
        public string PhotoPath { get; set; }
        public string Address { get; set; }
    }
}

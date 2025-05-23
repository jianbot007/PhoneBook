using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class userDTO
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string HashPassword { get; set; }
        public string PhoneNumber { get; set; }
    }
}

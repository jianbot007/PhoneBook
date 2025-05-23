using DataLayer.EFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class phoneDTO
    {
        public int id { get; set; }
        public string Number { get; set; }
        public string SimCompany { get; set; }
        public int ContactID { get; set; }

    }
}

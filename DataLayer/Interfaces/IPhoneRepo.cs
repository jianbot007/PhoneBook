using DataLayer.EFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IPhoneRepo : IRepo<phoneNumber,int,bool>
    {
        List<phoneNumber> GetbyContactId(int id);
    }
}

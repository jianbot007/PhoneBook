using DataLayer.EFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IContactRepo : IRepo<Contact,int,bool>
    {
        List<Contact> GetbyUserID(int id);

       int Creates(Contact obj);
    }
}

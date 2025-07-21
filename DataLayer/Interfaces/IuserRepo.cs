using DataLayer.EFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IuserRepo : IRepo<user,int,bool>

    {

        bool UpdatePassword(user obj);

        user Get(String Username);

    }
}

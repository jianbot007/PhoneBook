using DataLayer.EFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repos
{
    public class Repo
    {
        protected PhoneBookEntities db;

        public Repo()
        {
            db = new PhoneBookEntities();
        }
    }
}

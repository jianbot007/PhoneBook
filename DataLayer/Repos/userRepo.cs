using DataLayer.EFs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repos
{
    public class userRepo : Repo
    {
        public bool Create(user obj)
        {
     
            if (obj != null)
            {
                db.users.Add(obj);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(user obj)
        {

   
            if (obj != null)
            {
                var users = db.users.ToList();
                var user = (from u in users where obj.id == u.id select u).FirstOrDefault();
                user.PhoneNumber = obj.PhoneNumber;
                    user.HashPassword = obj.HashPassword;
                    db.SaveChanges();
                return true;
                            
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            var users = db.users.ToList();

            var user = (from u in users where id == u.id select u).FirstOrDefault();
            if (user != null)
            {
                db.users.Remove(user);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<user> Get()
        {
            return db.users.ToList();
        }
        public user Get(int id)
        {
            var users = db.users.ToList();
            var user = (from u in users where id == u.id select u).FirstOrDefault();
            return user;
        }

        public user Get(String Username)
        {
            var users = db.users.ToList();
            var user = (from u in users where Username == u.Username select u).FirstOrDefault();
            return user;
        }
    }
}

using DataLayer.EFs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repos
{
    internal class userRepo : Repo
    {
        public void Create(user obj)
        {
            var users = db.users.ToList();
            var userNameExist = (from u in users where obj.Username == u.Username select u).FirstOrDefault();
            if (obj != null && userNameExist == null)
            {
                db.users.Add(obj);
                db.SaveChanges();
            }
        }
        public void Update(user obj)
        {

            var users = db.users.ToList();
            var user = (from u in users where obj.id == u.id select u).FirstOrDefault();
            if (obj != null && user !=  null && obj.Username == user.Username)
            { 
       
                    user.PhoneNumber = obj.PhoneNumber;
                    user.HashPassword = obj.HashPassword;
                    db.SaveChanges();
                            
            }
        }
        public void Delete(int id)
        {
            var users = db.users.ToList();
            var user = (from u in users where id == u.id select u).FirstOrDefault();

            db.users.Remove(user);
            db.SaveChanges();
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
    }
}

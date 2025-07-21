using DataLayer.EFs;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repos
{
    internal class PhoneRepo : Repo,IRepo<phoneNumber,int,bool>,IPhoneRepo
    {
        public bool Create(phoneNumber obj)
        {
            if (obj != null)
            {
                db.phoneNumbers.Add(obj);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(phoneNumber obj)
        {
            if (obj != null)
            {
                var phones = db.phoneNumbers.ToList();
                var phone = (from p in phones where obj.id == p.id select p).FirstOrDefault();
                if(obj.Number.Length != 11)
                {
                    return false;
                }
                phone.ContactID = obj.ContactID;
                phone.SimCompany = obj.SimCompany;
                phone.Number = obj.Number;
                phone.Category = obj.Category;
               

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
            var phones = db.phoneNumbers.ToList();
            var phone = (from p in phones where id == p.id select p).FirstOrDefault();
            if(phone != null) { 
            db.phoneNumbers.Remove(phone);
            db.SaveChanges();
            return true;
        }
            else
            {
             return false;
            }
        }
        public List<phoneNumber> Get()
        {
            var phones = db.phoneNumbers.ToList();

            return phones;
        }
        public List<phoneNumber> GetbyContactId(int id)
        {
            var Allphones = db.phoneNumbers.ToList();
            var Targetphones = (from p in Allphones where id == p.ContactID select p).ToList();

            return Targetphones;
        }
        public phoneNumber Get(int id)
        {
            var Allphones = db.phoneNumbers.ToList();
            phoneNumber Targetphone = (from p in Allphones where id == p.id select p).SingleOrDefault();


            return Targetphone;
        }
    }
}

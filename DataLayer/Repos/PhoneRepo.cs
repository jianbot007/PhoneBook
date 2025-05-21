using DataLayer.EFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repos
{
    public class PhoneRepo : Repo
    {
        public void Create(phoneTable obj)
        {
            var phones = db.phoneTables.ToList();
            var phone = (from p in phones where obj.Number == p.Number select p).FirstOrDefault();
            if (obj != null && phone == null)
            {
                db.phoneTables.Add(obj);
                db.SaveChanges();
            }
        }
        public void Update(phoneTable obj)
        {
            if(obj != null)
            {
                var phones = db.phoneTables.ToList();
                var phone = (from p in phones where obj.id == p.id select p).FirstOrDefault();

                phone.ContactID = obj.ContactID;
                phone.SimCompany = obj.SimCompany;
                phone.Number = obj.Number;

                db.SaveChanges();

            }
        }
        public void Delete(int id)
        {
            var phones = db.phoneTables.ToList();
            var phone = (from p in phones where id == p.id select p).FirstOrDefault();

            db.phoneTables.Remove(phone);
        }
        public List<phoneTable> Get()
        {
            var phones = db.phoneTables.ToList();

            return phones;
        }
        public phoneTable Get(int id)
        {
            var phones = db.phoneTables.ToList();
            var phone = (from p in phones where id == p.id select p).FirstOrDefault();

            return phone;
        }
    }
}

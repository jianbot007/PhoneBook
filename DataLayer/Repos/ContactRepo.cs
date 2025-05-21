using DataLayer.EFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repos
{
    public class ContactRepo : Repo
    {  
       
        public void Create(Contact obj)
        {
            if (obj != null)
            {
                db.Contacts.Add(obj);
                db.SaveChanges();
            }
 
        }
        public void Update(Contact obj)
        {

            if (obj != null)
            {
                var contacts = db.Contacts.ToList();
                var contact = (from c in contacts where obj.id == c.id select c).FirstOrDefault();

                contact.Name = obj.Name;
                contact.Address = obj.Address;
                contact.PhotoPath = obj.PhotoPath;
                contact.Email = obj.Email;
                contact.Groups = obj.Groups;
                contact.user_id = obj.user_id;

                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var contacts = db.Contacts.ToList();
            var contact = (from c in contacts where id == c.id select c).FirstOrDefault();

            db.Contacts.Remove(contact);
            db.SaveChanges();
        }
        public List<Contact> Get()
        {
            var contacts = db.Contacts.ToList();
            return contacts;
        }
        public Contact Get(int id)
        {
            var contacts = db.Contacts.ToList();
            var contact = (from c in contacts where id == c.id select c).FirstOrDefault();

            return contact;
        }
    }
}

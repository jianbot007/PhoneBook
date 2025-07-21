using DataLayer.EFs;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace DataLayer.Repos
{
    internal class ContactRepo : Repo,IRepo<Contact,int,bool>,IContactRepo
    {

        public int Creates(Contact obj)
        {
            if (obj != null)
            {
              db.Contacts.Add(obj);
              db.SaveChanges();
                return obj.id;
                    }
            return -1; 
        }

        public bool Create(Contact obj)
        {
            return true;
        }

        public bool Update(Contact obj)
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
                return contact.user_id;
            }
            else
            {
                return -1;
            }
        }
        public bool Delete(int id)
        {
            var contacts = db.Contacts.ToList();
            var contact = (from c in contacts where id == c.id select c).FirstOrDefault();
            if (contact != null)
            {
                db.Contacts.Remove(contact);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Contact> Get()
        {
            var contacts = db.Contacts.ToList();
            return contacts;
        }
        public List<Contact> GetbyUserID(int id)
        {
            var Allcontacts = db.Contacts.ToList();
            var contacts = (from c in Allcontacts where id == c.user_id select c).ToList();

            return contacts;
        }
        public Contact Get(int id)
        {
            var Allcontacts = db.Contacts.ToList();
            var contact = (from c in Allcontacts where id == c.id select c).FirstOrDefault();

            return contact;
        }
    }
}

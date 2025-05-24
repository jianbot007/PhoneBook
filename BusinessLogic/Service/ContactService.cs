using BusinessLogic.DTOs;
using DataLayer.EFs;
using DataLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public class ContactService
    {
        
        public static List<ContactDTO> Get(int id)
        {
            ContactRepo contactRepo = new ContactRepo();
            var contacts = contactRepo.Get(id);

            return Convert(contacts);
        }
        public static List<ContactDTO> Get()
        {
            ContactRepo contactRepo = new ContactRepo();
            var contacts = contactRepo.Get();
            
            return Convert(contacts);
        }

        public static int Create(ContactDTO Data)
        {
                var contact = Convert(Data);
                ContactRepo contactRepo = new ContactRepo();
                return contactRepo.Create(contact);
        }

        public static bool Update(ContactDTO Data)
        {
                var contact = Convert(Data);
                ContactRepo contactRepo = new ContactRepo();
                return contactRepo.Update(contact);
        }
        public static bool Delete(int id)
        {
            ContactRepo contactRepo = new ContactRepo();
            return contactRepo.Delete(id); 
        }









        //DTO TO DATA ----- DATA TO DTO COnvertion
        public static List<ContactDTO> Convert(List<Contact> Data)
        {
            List<ContactDTO> contacts = new List<ContactDTO>();
            foreach (var item in Data)
            {
                var contact = Convert(item);
                contacts.Add(contact);
            }
            return contacts;
        }

        public static List<Contact> Convert(List<ContactDTO> Data)
        {
            List<Contact> contacts = new List<Contact>();
            foreach (var item in Data)
            {
                var contact = Convert(item);
                contacts.Add(contact);
            }
            return contacts;
        } 

        public static Contact Convert(ContactDTO Data)
        {
            Contact contact = new Contact();

            contact.id = Data.id;
            contact.user_id = Data.user_id;
            contact.PhotoPath = Data.PhotoPath;
            contact.Address = Data.Address;
            contact.Email = Data.Email;
            contact.Groups = Data.Groups;
            contact.Name = Data.Name;

            return contact;
        }
        public static ContactDTO Convert(Contact Data)
        {
            ContactDTO contactDTO = new ContactDTO();

            contactDTO.id = Data.id;
            contactDTO.user_id = Data.user_id;
            contactDTO.PhotoPath = Data.PhotoPath;
            contactDTO.Address = Data.Address;
            contactDTO.Email = Data.Email;
            contactDTO.Groups = Data.Groups;
            contactDTO.Name = Data.Name;

            return contactDTO;
        }
    }
}

using BusinessLogic.DTOs;
using DataLayer;
using DataLayer.EFs;
using DataLayer.Repos;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public class ContactService
    {
        
        public static List<ContactDTO> GetbyUserID(int id)
        {
        
            var contacts = DataAccess.AdvanceContactData().GetbyUserID(id);

            return Convert(contacts);
        }

        public static ContactDTO Get(int id)
        {
          
            var contact = DataAccess.ContactData().Get(id);

            return Convert(contact);
        }
        public static List<ContactDTO> Get()
        {
            
            var contacts = DataAccess.ContactData().Get();
            
            return Convert(contacts);
        }

        public static int Create(ContactDTO Data)
        {
            if (Data != null && Data.Email.Length <= 20)
            {
                var contact = Convert(Data);
              
                return DataAccess.AdvanceContactData().Creates(contact);
            }
            else
            {
                return -1;
            }
        }

        public static bool Update(ContactDTO Data)
        {
            if (Data != null && Data.Email.Length <= 20)
            {
                var Contact = Get(Data.id);
                Data.PhotoPath = Contact.PhotoPath;
                var contact = Convert(Data);
              
                return DataAccess.ContactData().Update(contact);
            }
            else
            {
                return false;
            }
        }
        public static bool Delete(int id)
        {
           
            return DataAccess.ContactData().Delete(id); 
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

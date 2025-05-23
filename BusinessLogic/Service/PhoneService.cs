using BusinessLogic.DTOs;
using DataLayer.EFs;
using DataLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public class PhoneService
    {
        public bool Create(phoneDTO Data)
        {
            PhoneRepo phoneRepo = new PhoneRepo();
            var phone = Convert(Data);

            return phoneRepo.Create(phone);

        }
        public bool Update(phoneDTO Data)
        {
            PhoneRepo phoneRepo = new PhoneRepo();
            var phone = Convert(Data);

            return phoneRepo.Update(phone);

        }
        public bool Delete(int id)
        {
            PhoneRepo phoneRepo = new PhoneRepo();
            return phoneRepo.Delete(id);

        }
        public List<phoneDTO> Get()
        {
            PhoneRepo phoneRepo = new PhoneRepo();

            var phones = phoneRepo.Get();
            if (phones == null) { return null; }
            else
            {
                return Convert(phones);
            }
          

        }
        public phoneDTO Get(int id)
        {
            PhoneRepo phoneRepo = new PhoneRepo();

            var phone = phoneRepo.Get(id);
            if (phone == null) { return null; }
            else
            {
                return Convert(phone);
            }
        }

        //Convertion between data and DTO

        public static List<phoneTable> Convert(List<phoneDTO> Data)
        {
            List<phoneTable> phones = new List<phoneTable>();

            foreach (var item in Data)
            {
                var phone = Convert(item);
                phones.Add(phone);
            }
            return phones;
        }

        public static List<phoneDTO> Convert(List<phoneTable> Data)
        {
            List<phoneDTO> phones = new List<phoneDTO>();

            foreach(var item in Data)
            {
                var phone = Convert(item);
                phones.Add(phone);
            }
            return phones;
        }
        public static phoneDTO Convert(phoneTable Data)
        {
            phoneDTO phoneDTO = new phoneDTO();

            phoneDTO.ContactID = Data.ContactID;
            phoneDTO.id = Data.id;
            phoneDTO.Number = Data.Number;
            phoneDTO.SimCompany = Data.SimCompany;

            return phoneDTO;
        }

        public static phoneTable Convert(phoneDTO Data)
        {
            phoneTable phone = new phoneTable();

            phone.ContactID = Data.ContactID;
            phone.id = Data.id;
            phone.Number = Data.Number;
            phone.SimCompany = Data.SimCompany;
            
            return phone;
        }

    }
}

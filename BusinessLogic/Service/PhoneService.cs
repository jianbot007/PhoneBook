using BusinessLogic.DTOs;
using DataLayer;
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
        public static bool Create(phoneDTO Data)
        {   
          
            if (Data != null)
            {    if(Data.Number.Length != 11 || Data.Number[0] != '0' || Data.Number[1] != '1')
                {
                    return false;
                }
                if(Data.Category == null)
                {
                    Data.Category = "Unknown";
                }
                if (Data.SimCompany == null)
                {
                    if (Data.Number[2] == '7' || Data.Number[2] == '3')
                    {
                        Data.SimCompany = "GrameenPhone";
                    }
                    else if (Data.Number[2] == '4' || Data.Number[2] == '9')
                    {
                        Data.SimCompany = "Banglalink";
                    }
                    else if (Data.Number[2] == '8' || Data.Number[2] == '6')
                    {
                        Data.SimCompany = "Robi";
                    }
                    else if (Data.Number[2] == '5' )
                    {
                        Data.SimCompany = "TeleTalk";
                    }
                    else
                    {
                        Data.SimCompany = "Unknown";
                    }
                    var phone = Convert(Data);
                    return DataAccess.PhoneData().Create(phone);
                }
            }

            return false;
        }
        public static bool Update(phoneDTO Data)
        {
            if (Data.Category == null)
            {
                Data.Category = "Unknown";
            }
            if (Data.SimCompany == null)
            {
                if (Data.Number[2] == '7' || Data.Number[2] == '3')
                {
                    Data.SimCompany = "GrameenPhone";
                }
                else if (Data.Number[2] == '4' || Data.Number[2] == '9')
                {
                    Data.SimCompany = "Banglalink";
                }
                else if (Data.Number[2] == '8' || Data.Number[2] == '6')
                {
                    Data.SimCompany = "Robi";
                }
                else if (Data.Number[2] == '5')
                {
                    Data.SimCompany = "TeleTalk";
                }
                else
                {
                    Data.SimCompany = "Unknown";
                }
            }
              
            var phone = Convert(Data);

            return DataAccess.PhoneData().Update(phone);
        }
        public static bool Delete(int id)
        {
          
            return DataAccess.PhoneData().Delete(id);

        }
        public static List<phoneDTO> Get()
        {
          

            var phones = DataAccess.PhoneData().Get();
            if (phones == null) { return null; }
            else
            {
                return Convert(phones);
            }
          

        }
        public static List<phoneDTO> GetbyContactid(int id)
        {
          
            var phones = DataAccess.AdvancePhoneData().GetbyContactId(id);
            if (phones == null) { return null; }
            else
            {
                return Convert(phones);
            }
        }
        public static phoneDTO Get(int id)
        {
            
            var phone = DataAccess.PhoneData().Get(id);
            if (phone == null) { return null; }
            else
            {
                return Convert(phone);
            }
        }

        //Convertion between data and DTO

        public static List<phoneNumber> Convert(List<phoneDTO> Data)
        {
            List<phoneNumber> phones = new List<phoneNumber>();

            foreach (var item in Data)
            {
                var phone = Convert(item);
                phones.Add(phone);
            }
            return phones;
        }

        public static List<phoneDTO> Convert(List<phoneNumber> Data)
        {
            List<phoneDTO> phones = new List<phoneDTO>();

            foreach(var item in Data)
            {
                var phone = Convert(item);
                phones.Add(phone);
            }
            return phones;
        }
        public static phoneDTO Convert(phoneNumber Data)
        {
            phoneDTO phoneDTO = new phoneDTO();

            phoneDTO.ContactID = Data.ContactID;
            phoneDTO.id = Data.id;
            phoneDTO.Number = Data.Number;
            phoneDTO.SimCompany = Data.SimCompany;
            phoneDTO.Category = Data.Category;

            return phoneDTO;
        }

        public static phoneNumber Convert(phoneDTO Data)
        {
            phoneNumber phone = new phoneNumber();

            phone.ContactID = Data.ContactID;
            phone.id = Data.id;
            phone.Number = Data.Number;
            phone.SimCompany = Data.SimCompany;
            phone.Category = Data.Category;
            
            return phone;
        }

    }
}

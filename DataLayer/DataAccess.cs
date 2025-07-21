using DataLayer.EFs;
using DataLayer.Interfaces;
using DataLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataAccess
    {
        public static IRepo<Contact, int, bool> ContactData()
        {
            return new ContactRepo();
        }
        public static IContactRepo AdvanceContactData()
        {
            return new ContactRepo();
        }
        public static IRepo<user, int, bool> UserData()
        {
            return new userRepo();
        }
        public static IuserRepo AdvanceUserData()
        {
            return new userRepo();
        }
        public static IRepo<phoneNumber, int, bool> PhoneData()
        {
            return new PhoneRepo();
        }
        public static IPhoneRepo AdvancePhoneData()
        {
            return new PhoneRepo();
        }
    }
}

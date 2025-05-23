using BusinessLogic.DTOs;
using DataLayer.EFs;
using DataLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public class UserService
    {

        public static bool Authentication(String Username , String Password)
        {    

            var hashPassword = HashPassword(Password);
            var Users = Get();
            var UserPassword = (from u in Users where u.Username == Username select u.HashPassword).FirstOrDefault();

            if(hashPassword == UserPassword)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool Create(userDTO Data)
        {  
           
            var users = Get();
            var userCheck = (from u in users where Data.Username == u.Username select u).FirstOrDefault();
            var phonecheck = (from u in users where Data.PhoneNumber == u.PhoneNumber select u).FirstOrDefault();
            if (userCheck != null || phonecheck != null)
            {
                return false;
            }
            var user = Convert(Data);
            user.HashPassword = HashPassword(Data.HashPassword);
            userRepo userRepo = new userRepo();
            return userRepo.Create(user);
         
        }
        public static bool Update(userDTO Data)
        {
            var users = Get();
            var userCheck = (from u in users where Data.Username == u.Username select u).FirstOrDefault();
            var phonecheck = (from u in users where Data.PhoneNumber == u.PhoneNumber select u).FirstOrDefault();
            if (userCheck != null || phonecheck != null)
            {
                return false;
            }
            var user = Convert(Data);
            user.HashPassword = HashPassword(Data.HashPassword);
            userRepo userRepo = new userRepo();
            return userRepo.Update(user);

        }
        public static bool Delete(int id)
        {
            userRepo userRepo = new userRepo();

            return userRepo.Delete(id);

        }
        public static List<userDTO> Get()
        {

            userRepo userRepo = new userRepo();
            var users = userRepo.Get();
            if (users == null)
            {
                return null;
            }
            else
            {
                return Convert(users);
            }
        }
        public static userDTO Get(int id)
        {
            userRepo userRepo = new userRepo();
            var user = userRepo.Get(id);
            if (user == null)
            {
                return null;
            }
            else
            {
                return Convert(user);
            }
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return System.Convert.ToBase64String(hashBytes);
            }
        }
        //Convertion of DTO to data -- data to DTA

        public static List<user> Convert(List<userDTO> Data)
        {
            List<user> users = new List<user>();
            foreach (var item in Data)
            {
                user user = Convert(item);
                users.Add(user);
            }
            return users;
        }

        public static List<userDTO> Convert(List<user> Data)
        {
            List<userDTO> users = new List<userDTO>();
            foreach(var item in Data)
            {
                userDTO user = Convert(item);
                users.Add(user);
            }
            return users;
        }

        public static userDTO Convert(user Data)
        {
            userDTO userDTO = new userDTO();

            userDTO.id = Data.id;
            userDTO.PhoneNumber = Data.PhoneNumber;
            userDTO.HashPassword = Data.HashPassword;
            userDTO.Username = Data.Username;

            return userDTO;
        }
        public static user Convert(userDTO Data)
        {
            user user = new user();

            user.id = Data.id;
            user.PhoneNumber = Data.PhoneNumber;
            user.HashPassword = Data.HashPassword;
            user.Username = Data.Username;

            return user;
        }
    }
}

using BusinessLogic.DTOs;
using BusinessLogic.Service;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using PhoneBookApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace PhoneBookApplication.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult DashBoard()
        {
            userDTO user = Session["User"] as userDTO;
            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View(user);
        }

        public ActionResult ContactList()
        {
            var user = Session["User"] as userDTO;
            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var userID = user.id;
            var ContactList = ContactService.GetbyUserID(userID);

            var Allphones = PhoneService.Get();
            List<ContactPhone> contactPhoneList = new List<ContactPhone>();
            foreach (var contact in ContactList)
            {

                var contactID = contact.id;
                var phoneList = (from p in Allphones where p.ContactID == contactID select p).ToList();

                ContactPhone contactPhone = new ContactPhone();
                contactPhone.contact = contact;
                contactPhone.phones = phoneList;

                contactPhoneList.Add(contactPhone);
            }


            return View(contactPhoneList);
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");
        }
        public ActionResult Deactive(int id)
        {
            var user = Session["User"] as userDTO;
            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var AllContactList = ContactService.Get();
            var AllPhones = PhoneService.Get();
            var User = UserService.Get(id);

            var ContactList = (from C in AllContactList where C.user_id == id select C).ToList();

            foreach(var contact in ContactList)
            {
                var Phones = (from P in AllPhones where P.ContactID == contact.id select P).ToList();
                foreach(var phone in Phones)
                {
                    PhoneService.Delete(phone.id);
                }
                ContactService.Delete(contact.id);
            }

            UserService.Delete(id);
            HttpContext.Session.Clear();
            

            return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public ActionResult EditProfile(int id)
        {
            var user = Session["User"] as userDTO;
            if (user == null || id == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var User = UserService.Get(id);

            return View(User);
        }
        [HttpPost]
        public ActionResult EditProfile(int id, String Username, String PhoneNumber)
        {
            var user = Session["User"] as userDTO;
            if (user == null || id == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var User = UserService.Get(id);

            User.Username = Username;
            User.PhoneNumber = PhoneNumber;


            if (UserService.Update(User))
            {
                Session["User"] = User;
                return RedirectToAction("DashBoard", "Home");
            }
            else
            {
                TempData["msg"] = "Update Information Failed Try agian";
                return View(User);
            }
        }

        [HttpGet]
        public ActionResult PasswordChange(int id)
        {
            var User = UserService.Get(id);

            return View(User);
        }

        [HttpPost]
        public ActionResult PasswordChange(int id, String OldPassword, String NewPassword, String ConfirmPassword)
        {
            var User = UserService.Get(id);
            if (NewPassword != ConfirmPassword)
            {
                TempData["msg"] = "New Password and Confirm Password are not same,Try again";
                return View(User);
            }
            if (NewPassword == OldPassword)
            {
                TempData["msg"] = "New Password and Old Password are same,Try again";
                return View(User);
            }
            if (NewPassword.Length < 8)
            {
                TempData["msg"] = "New Password Must be length of 8,Try again";
                return View(User);
            }
            User.HashPassword = NewPassword;
            if (UserService.UpdatePassword(User))
            {
                return RedirectToAction("DashBoard", "Home");
            }
            else
            {
                TempData["msg"] = "Password Change Failed,Try Again";
                return View(User);
            }

        
    
        }
    }
}
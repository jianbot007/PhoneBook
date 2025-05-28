using BusinessLogic.DTOs;
using BusinessLogic.Service;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using PhoneBookApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

        public ActionResult ContactList(String filterbyGroup,String searchItem)
        {
            var user = Session["User"] as userDTO;
            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var userID = user.id;


            List<ContactDTO> ContactList = ContactService.GetbyUserID(userID);
            if(searchItem != null)
            {
                searchItem = searchItem.ToLower();

                ContactList = (from c in ContactList where c.Name.ToLower().Contains(searchItem) || c.Groups.ToLower().Contains(searchItem) select c).ToList();
            }
            
            if (filterbyGroup != null)
            {
                ContactList = (from c in ContactList where c.Groups == filterbyGroup select c).ToList();
            }
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
        public ActionResult Download()
        {
            var user = Session["User"] as userDTO;
            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var contactList = ContactService.GetbyUserID(user.id);
            var AllphoneList = PhoneService.Get();

            using (var package = new ExcelPackage())
            {

    
                var worksheet = package.Workbook.Worksheets.Add("Contacts");



                worksheet.Cells[1, 1].Value = "Name";
                worksheet.Cells[1, 2].Value = "Email";
                worksheet.Cells[1, 3].Value = "Group";
                worksheet.Cells[1, 4].Value = "Address";
                worksheet.Cells[1, 5].Value = "Phone Numbers";



                int row = 2;
                foreach (var contact in contactList)
                {
                    var phonesList = (from p in AllphoneList where p.ContactID == contact.id select p.Number).ToList();
                    string phoneNumbersString = string.Join(", ", phonesList);
                    worksheet.Cells[row, 1].Value = contact.Name;
                    worksheet.Cells[row, 2].Value = contact.Email;
                    worksheet.Cells[row, 3].Value = contact.Groups;
                    worksheet.Cells[row, 4].Value = contact.Address;
                    worksheet.Cells[row, 5].Value = phoneNumbersString;
                    row++;
                }


                worksheet.Cells.AutoFitColumns();

                var stream = new MemoryStream(package.GetAsByteArray());

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Contacts.xlsx");
            }
        }
    }
}
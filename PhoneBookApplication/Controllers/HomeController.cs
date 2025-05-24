using BusinessLogic.DTOs;
using BusinessLogic.Service;
using Microsoft.Ajax.Utilities;
using PhoneBookApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBookApplication.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult DashBoard()
        {
            userDTO user = Session["User"] as userDTO;
            if(user == null)
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
            var ContactList = ContactService.Get(userID);

            var Allphones = PhoneService.Get();
            List<ContactPhone> contactPhoneList = new List<ContactPhone>();
            foreach(var contact in ContactList)
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
    
       

     

    }
}
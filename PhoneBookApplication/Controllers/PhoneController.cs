using BusinessLogic.DTOs;
using BusinessLogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace PhoneBookApplication.Controllers
{
    public class PhoneController : Controller
    {
        public ActionResult DeletePhone(int id)
        {
            userDTO user = Session["User"] as userDTO;
            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            PhoneService.Delete(id);

            return RedirectToAction("ContactList", "Home");
        }

        public ActionResult EditPhone(int id)
        {
            userDTO user = Session["User"] as userDTO;
            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            phoneDTO Data = PhoneService.Get(id);
            
            
            return View(Data);
        }

        [HttpPost]
        public ActionResult EditPhone(String Number,String Category,int ContactID,int id)
        {
            userDTO user = Session["User"] as userDTO;
            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            phoneDTO phone = new phoneDTO();

            phone.Category = Category;
            phone.Number = Number;
            phone.ContactID = ContactID;
            phone.id = id;

            if (PhoneService.Update(phone))
            {
                return RedirectToAction("ContactList", "Home");
            }
            else
            {
                TempData["msg"] = "Edit failed ,Please Try Again";
                return View(phone);
            }   
        }
        [HttpGet]
        public ActionResult AddNumber(int id)
        {
            userDTO user = Session["User"] as userDTO;
            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View(id);
        }
        [HttpPost]
        public ActionResult AddNumber(int ContactID,String Number,String Category)
        {
            userDTO user = Session["User"] as userDTO;
            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            phoneDTO phone = new phoneDTO();

            phone.Category = Category;
            phone.Number = Number;
            phone.ContactID = ContactID;

            if (PhoneService.Create(phone))
            {
                return RedirectToAction("ContactList", "Home");
            }
            else
            {
                TempData["msg"] = "Number Add failed ,Please Try Again";
                return View(ContactID);
            }
        }
    }
}
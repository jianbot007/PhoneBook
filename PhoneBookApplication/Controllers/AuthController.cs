using BusinessLogic.DTOs;
using BusinessLogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBookApplication.Controllers
{
    public class AuthController : Controller
    {   

       [HttpGet]
       public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
       public ActionResult Login(String Username,String Password)
        {

           bool auth = UserService.Authentication(Username, Password);
            if (auth)
            {
                return RedirectToAction("DashBoard", "Home");
            }
            else
            {
                ViewBag.Error = "Invalid username or password";
                return View();
            }
        }

     
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(String Username,String Password,String PhoneNumber)
        {
            var userDTO = new userDTO();
            if(Password.Length < 8)
            {
                ViewBag.Error = "Password length must 8 or more, Please Try Again";
                return View();
            }
            
            userDTO.PhoneNumber = PhoneNumber;
            userDTO.Username = Username;
            userDTO.HashPassword = Password;

            var create = UserService.Create(userDTO);
            if (create)
            {
                Session["Username"] = Username;
                return RedirectToAction("DashBoard","Home");
            }
            else
            { 
                ViewBag.Error = "Registration Failed,Please Change Username or PhoneNumber and Try Again";
                return View();
            }
        }

    }
}
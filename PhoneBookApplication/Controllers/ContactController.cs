using BusinessLogic.DTOs;
using BusinessLogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBookApplication.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public ActionResult AddContact()
        {
            var user = Session["User"] as userDTO;

            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(String name, String email, String address, String group, String Number1, String Number2, String Number3, String Category1, String Category2, String Category3)
        {
            if (ModelState.IsValid)
            {
                var user = Session["User"] as userDTO;
                int userID = user.id;
                if (user == null)
                {
                    return RedirectToAction("Login", "Auth");
                }
                ContactDTO contact = new ContactDTO();
                contact.user_id = userID;
                contact.Address = address;
                contact.Name = name;
                contact.Email = email;
                contact.Groups = group;
                contact.PhotoPath = null;
                int contactId = ContactService.Create(contact);
                if (contact != null)
                {
                    if (contactId != 0)
                    {
                        if (Number1.Length == 11 && Number1[0] == '0' && Number1[1] == '1' && Number1.Length == 11)
                        {
                            phoneDTO phone1 = new phoneDTO();
                            phone1.Number = Number1;
                            phone1.Category = Category1;
                            phone1.ContactID = contactId;
                            PhoneService.Create(phone1);
                        }


                        if (Number2.Length == 11)
                        {
                            if (Number2[0] == '0' && Number2[1] == '1' && Number2.Length == 11)
                            {

                                phoneDTO phone2 = new phoneDTO();
                                phone2.Number = Number2;
                                phone2.Category = Category2;
                                phone2.ContactID = contactId;
                                PhoneService.Create(phone2);

                            }
                        }

                        if (Number3.Length == 11)
                        {
                            if (Number3[0] == '0' && Number3[1] == '1' && Number3.Length == 11)
                            {
                                phoneDTO phone3 = new phoneDTO();
                                phone3.Number = Number3;
                                phone3.Category = Category3;
                                phone3.ContactID = contactId;
                                PhoneService.Create(phone3);
                            }
                        }

                        return RedirectToAction("ContactList", "Home");
                    }
                    else
                    {
                        return RedirectToAction("AddContact", "Home");
                    }
                }

                TempData["msg"] = "Contact Added to List";
                TempData["class"] = "alert alert-success";
                return RedirectToAction("ContactList", "Home");
            }
            else
            {
                TempData["msg"] = "Invalid length ,Please try again";
                TempData["class"] = "alert alert-warning";
                return View();
            }

        }

        public ActionResult DeleteContact(int id)
        {   
            //Delete Phone Number to includes in this id
            var AllPhone = PhoneService.Get();
            var TargetPhonelist = (from Ap in AllPhone where Ap.ContactID == id select Ap).ToList();
            foreach(var item in TargetPhonelist)
            {
                PhoneService.Delete(item.id);
            }
            //DeleteContact
            ContactService.Delete(id);

            
            return RedirectToAction("ContactList", "Home");
        }


        //Phone Related Function 
        public ActionResult DeletePhone(int id)
        {
            bool AllPhones = PhoneService.Delete(id);
            return RedirectToAction("ContactList", "Home");
        }

    }
}
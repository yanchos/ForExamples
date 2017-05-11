using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Views.RegistrationPage
{
    public class RegistrationPageController : Controller
    {
        CinemaddictEntities2 db = new CinemaddictEntities2();
        // GET: RegistrationPage
        public ActionResult RegistrationPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(string inputNumber,string inputName,string inputNickname, string inputMobileNumber, string inputEmail, string inputPassword)
        {
            if ((inputEmail != "")&&(inputPassword != ""))
            {
                if (inputName == "") inputName = " ";
                if (inputNickname == "") inputNickname = " ";
                if (inputMobileNumber == "") inputMobileNumber = " ";
                Models.Users new_user = new Models.Users
                {
                    ID_User = 1,
                    Name = inputName,
                    Nickname = inputNickname,
                    MobileNumber = inputMobileNumber,
                    Email = inputEmail,
                    Checker = false,
                    Password = inputPassword
                };
                db.Users.Add(new_user);
                db.SaveChanges();
                Session["session_user_id"] = new_user.ID_User;
                Session["session_user_name"] = new_user.Name;
                Session["session_user_nickname"] = new_user.Nickname;
                Session["session_user_mobile_number"] = new_user.MobileNumber;
                Session["session_user_email"] = new_user.Email;
                Session["session_user_checker"] = new_user.Checker;
                Session["session_user_password"] = new_user.Password;
                ViewBag.registration = 1;
                return RedirectToAction("PersonalPage", "PersonalPage");
            }
            ViewBag.registration = -1;
            return View("RegistrationPage");
        }

        [HttpPost]
        public ActionResult RegCancel()
        {
            ViewBag.registration = 0;
            return View("RegistrationPage", "RegistrationPage");
        }
    }
}
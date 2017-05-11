using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Views.EntryPage
{
    public class EntryPageController : Controller
    {
        CinemaddictEntities2 db = new CinemaddictEntities2();
        // GET: EnrtyPage
        public ActionResult EntryPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string inputEmail, string inputPassword)
        {
            var session_user = db.Users.FirstOrDefault(p => p.Email == inputEmail);
            if ((session_user != null) && (inputPassword == session_user.Password))
            {
                Session["session_user_id"] = session_user.ID_User;
                Session["session_user_name"] = session_user.Name;
                Session["session_user_nickname"] = session_user.Nickname;
                Session["session_user_mobile_number"] = session_user.MobileNumber;
                Session["session_user_email"] = session_user.Email;
                Session["session_user_checker"] = session_user.Checker;
                Session["session_user_password"] = session_user.Password;
                ViewBag.login = 1;
                return RedirectToAction("PersonalPage", "PersonalPage");
            }
            ViewBag.login = -1;
            return View("EntryPage");
        }

        [HttpPost]
        public ActionResult LogCancel()
        {
            Session["session_user_name"] = "N/A";
            Session["session_user_checker"] = "False";
            ViewBag.login = 0;
            return View("EntryPage", "EntryPage");
        }
    }
}
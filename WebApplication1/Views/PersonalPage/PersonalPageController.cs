using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Views.PersonalPage
{
    public class PersonalPageController : Controller
    {
        CinemaddictEntities2 db = new CinemaddictEntities2();
        // GET: PersonalPage
        public ActionResult PersonalPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            Session["session_user_nickname"] = "N/A";
            Session["session_user_checker"] = "False";
            return RedirectToAction("MainPage", "MainPage", db.Movies);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Views.MainPage
{
    public class MainPageController : Controller
    {
        CinemaddictEntities2 db = new CinemaddictEntities2();
        // GET: MainPage
        public ActionResult MainPage()
        {
            return View(db.Movies);
        }

        public ActionResult MainPageStart()
        {
            Session["session_user_nickname"] = "N/A";
            Session["session_user_checker"] = "False";
            return View("MainPage", db.Movies);
        }
    }
}
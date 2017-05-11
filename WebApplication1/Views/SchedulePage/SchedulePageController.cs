using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Views.SchedulePage
{
    public class SchedulePageController : Controller
    {
        CinemaddictEntities2 db = new CinemaddictEntities2();

        // GET: SchedulePage
        public ActionResult SchedulePage()
        {
            var sessions = db.Sessions.Include("Movies").ToList();
            List<Movies> movies = new List<Movies>();
            foreach(var session in sessions)
            {
                if (!movies.Contains(session.Movies))
                {
                    movies.Add(session.Movies);
                }
            }
            return View(movies);
        }
    }
}
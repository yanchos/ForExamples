using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Views.DeleteMoviePage
{
    public class DeleteMoviePageController : Controller
    {
        CinemaddictEntities2 db = new CinemaddictEntities2();
        // GET: DeleteMoviePage
        public ActionResult DeleteMoviePage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebApplication1.Models.Movies movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: DeleteMoviePage/DeleteMoviePage/5
        [HttpPost, ActionName("DeleteMoviePage")]
        public ActionResult DeleteMoviePage(int id)
        {
            WebApplication1.Models.Movies movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("MainPage","MainPage");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Views.AddMoviePage
{
    public class AddMoviePageController : Controller
    {
        CinemaddictEntities2 db = new CinemaddictEntities2();
        // GET: AddMoviePage
        public ActionResult AddMoviePage()
        {
            if (Session["tmp_img"] == null) Session["tmp_img"] = "/UpImages/no-image-icon.png";
            ViewBag.ID_Genre1 = new SelectList(db.Genres, "ID_Genre", "Name");
            ViewBag.ID_Genre2 = new SelectList(db.Genres, "ID_Genre", "Name");
            ViewBag.ID_Genre3 = new SelectList(db.Genres, "ID_Genre", "Name");
            ViewBag.ID_Country = new SelectList(db.Countries, "ID_Country", "Name");
            ViewBag.ID_AgeRestriction = new SelectList(db.AgeRestrictions, "ID_AgeRestriction", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult AddMoviePage([Bind(Include = "ID_Movie,Name,Description,ID_AgeRestriction,Poster,Trailer,Duration,Scriptwriters,Directors,Producers,Actors,ID_Country,ID_Genre1,ID_Genre2,ID_Genre3")] WebApplication1.Models.Movies movie)
        {
            if (ModelState.IsValid)
            {
                movie.Poster = Session["tmp_img"].ToString();
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("MainPage", "MainPage");
            }

            ViewBag.ID_Genre1 = new SelectList(db.Genres, "ID_Genre", "Name", movie.ID_Genre1);
            ViewBag.ID_Genre2 = new SelectList(db.Genres, "ID_Genre", "Name", movie.ID_Genre2);
            ViewBag.ID_Genre3 = new SelectList(db.Genres, "ID_Genre", "Name", movie.ID_Genre3);
            ViewBag.ID_Country = new SelectList(db.Countries, "ID_Country", "Name", movie.ID_Country);
            ViewBag.ID_AgeRestriction = new SelectList(db.AgeRestrictions, "ID_AgeRestriction", "Name", movie.ID_AgeRestriction);
            return View(movie);
        }

        [HttpPost]
        public ActionResult UploadPicture(IEnumerable<HttpPostedFileBase> fileUpload)
        {
            string tmp_img = Session["tmp_img"].ToString();
            foreach (var file in fileUpload)
            {
                if (file == null) continue;
                string path = AppDomain.CurrentDomain.BaseDirectory + "UpImages/";
                string path_db = "/UpImages/";
                string filename = Path.GetFileName(file.FileName);
                if (filename == null) filename = "no-image-icon.png";
                file.SaveAs(Path.Combine(path, filename));
                path_db += filename;
                if (filename != null) tmp_img = path_db;
            }
            if (tmp_img != null) Session["tmp_img"] = tmp_img;
            else Session["tmp_img"] = "/UpImages/no-image-icon.png";
            return RedirectToAction("AddMoviePage", "AddMoviePage");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
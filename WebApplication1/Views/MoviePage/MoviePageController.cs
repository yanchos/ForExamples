using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Views.MoviePage
{
    public class MoviePageController : Controller
    {
        CinemaddictEntities2 db = new CinemaddictEntities2();
        // GET: MoviePage
        public ActionResult MoviePage(int cur_movie)
        {
            var movie = db.Movies.First(m => m.ID_Movie == cur_movie);
            var age = db.AgeRestrictions.First(m => m.ID_AgeRestriction == movie.ID_AgeRestriction);
            var country = db.Countries.First(m => m.ID_Country == movie.ID_Country);
            var genre1 = db.Genres.First(m => m.ID_Genre == movie.ID_Genre1);
            var genre2 = db.Genres.FirstOrDefault(m => m.ID_Genre == movie.ID_Genre2);
            if (genre2 == null) ViewBag.genre2 = "-";
            else ViewBag.genre2 = genre2.Name;
            var genre3 = db.Genres.FirstOrDefault(m => m.ID_Genre == movie.ID_Genre3);
            if (genre3 == null) ViewBag.genre3 = "-";
            else ViewBag.genre3 = genre3.Name;
            ViewBag.name = movie.Name;
            ViewBag.description = movie.Description;
            ViewBag.age = age.Name;
            ViewBag.poster = movie.Poster;
            ViewBag.trailer = movie.Trailer;
            ViewBag.duration = movie.Duration;
            ViewBag.scriptwriters = movie.Scriptwriters;
            ViewBag.directors = movie.Directors;
            ViewBag.producers = movie.Producers;
            ViewBag.actors = movie.Actors;
            ViewBag.country = country.Name;
            ViewBag.genre1 = genre1.Name;
            return View();
        }
    }
}
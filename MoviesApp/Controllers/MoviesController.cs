using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    public class MoviesController : Controller
    {
        public static List<Movie> _movies = new List<Movie>
        {
            new Movie{ID = 1, Title = "Pierwszy", Description="lorem ipsum", ReleaseDate = DateTime.Today}
        };
        // GET: Movies
        public ActionResult Index()
        {
            var model = _movies;
            return View(model);
        }

        
        
        public ActionResult Details(int id)
        {
            var movie = _movies.Single(m => m.ID == id);
            return View(movie);
        }
         

        public ActionResult Create()
        {
            return View();
        }
        
        public ActionResult Edit(int id)
        {
            var movie = _movies.Single(m => m.ID == id);
            return View(movie);
        }
        [HttpPost]
        public ActionResult Edit(int id, Movie movies)
        {
            var movie = _movies.Single(m => m.ID == id);
            if (TryUpdateModel(movie))
            {
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        
        public ActionResult Delete(int id)
        {
            return View();
        }


      
    }
}
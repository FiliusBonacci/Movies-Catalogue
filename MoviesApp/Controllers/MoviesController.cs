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
            new Movie{ID = 1, Title = "Pierwszy", Description="lorem ipsum", ReleaseDate = DateTime.Today.Year.ToString()},
            new Movie{ID = 2, Title = "Drugi Film", Description="lorem ipsumf sdf sdf ", ReleaseDate = DateTime.Today.Year.ToString()},
            new Movie{ID = 3, Title = "Trzeci film", Description="lorem ipsum sdf sdf", ReleaseDate = DateTime.Today.Year.ToString()},
            new Movie{ID = 4, Title = "Ostatni", Description="lorem ipsum asdasdas sff ", ReleaseDate = DateTime.Today.Year.ToString()},
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


        [ChildActionOnly]
        public ActionResult BestMovie()
        {
            var model = _movies.First();
            return PartialView("_SingleMovie", model);
        }
    }
}
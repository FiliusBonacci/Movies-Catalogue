using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    public class MoviesController : BaseController
    {
        public static List<Movie> _movies = new List<Movie>
         {
            new Movie{ID = 1, Title = "Pierwszy", Description="lorem ipsum", ReleaseDate = DateTime.Today.Year.ToString()}
         };

        // GET: Movies
        public ActionResult Index()
        {

            var model = _db.Movies;
                        
            return View(model);
        }

        public ActionResult Search(string search = null)
        {
            IEnumerable<Movie> model;
            if (!string.IsNullOrEmpty(search))
            {
                model = _db.Movies.Where(m => m.Title.Contains(search));
            } else
            {
                model = _db.Movies;
            }
            
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var movie = _db.Movies.Where(m => m.ID.Equals(id));
            return View((Movie) movie);
        }
         

        public ActionResult Create()
        {
            return View();
        }
        
        public ActionResult Edit(int id)
        {
            var movie = from m in _db.Movies
                        where m.ID == id
                        select m;
            return View((Movie) movie);
        }
        [HttpPost]
        public ActionResult Edit(int id, Movie movies)
        {
            var movie = from m in _db.Movies
                        where m.ID == id
                        select m;
            if (TryUpdateModel(movie))
            {
                return RedirectToAction("Index");
            }
            return View((Movie) movie);
        }
        
        public ActionResult Delete(int id)
        {
            return View();
        }


        [ChildActionOnly]
        public ActionResult BestMovie()
        {
            var model = _movies.First();
            return PartialView("_SingleMovie", (Movie) model);
        }
    }
}
using blackBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blackBox.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            var movie = GetMovies();
            return View(movie);
        }

        public ActionResult Direct(int? id)
        {
            var movie = GetMovies().SingleOrDefault(param => param.Id == id);
            if(movie == null)
            {
                return HttpNotFound("Selected movie Id not found in our server!");
            }
            return View(movie);
        }


        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id = 1, Name = "Shrek"},
                new Movie {Id = 2, Name = "Wall-E"}
            };
        }
    }
}
using blackBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using blackBox.ViewModels;

namespace blackBox.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movie
        public ActionResult Index()
        {
            var movie = _context.Movies.Include(c => c.Genre);

            return View(movie);
        }


        public ActionResult Direct(int? id)
        {
            var movie = _context.Movies.SingleOrDefault(param => param.Id == id);
            if(movie == null)
            {
                return HttpNotFound("Selected movie Id not found in our server!");
            }
            return View(movie);
        }

        // FORM ActionResults

        public ActionResult MovieForm()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genres,
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveMovieForm(Movie movie)
        {
            //checks object values passed from form satisfies dataAnnotation requirements set in model.
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(e => e.Errors);
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if(movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }

            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                //refactor with mapper class
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NoOfStock = movie.NoOfStock;
                movieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }
        public ActionResult EditForm(int id)
        {
            var selectedMovie = _context.Movies.Single(m => m.Id == id);
            
            if(selectedMovie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                Movie = selectedMovie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm",viewModel);
        }
    }
}
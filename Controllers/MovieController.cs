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
                Genres = genres,
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SaveMovieForm(Movie movie)
        {
            if(movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NoOfStock = movie.NoOfStock;
                movieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }
        //1.form page <-- pass MovieFormViewModel 
        //1.1.View page: contain h2, form (Name, ReleaseDate, Genre) + Id, Date added + No of Stock (hidden).

        //2.saveForm [httpPost] TRIGGERED BY SUBMIT BTN<-- pass movie in, 
        //i.Add new f(x): Check if Id == null, to add NEW movie to list db.
        //ii.Edit f(x) ELSE : Edit by assigning new var to hold movie properties via dbContext.Single()
        ///iii. Redirect to Movie main page (action name, controller name)

        //3.EditForm <-- (int id) passed from htmlActionlink(). 
        //i. Query id to db movie.id match, if null display page error
        //ii. create Viewmodel object that contains both movie + genre properties
        //iii. return formpage (action name, controller name)
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
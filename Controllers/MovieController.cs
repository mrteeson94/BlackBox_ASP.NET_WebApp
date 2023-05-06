using blackBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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
    }
}
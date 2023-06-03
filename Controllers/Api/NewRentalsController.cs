using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using blackBox.Models;
using blackBox.Dtos;
using AutoMapper;

namespace blackBox.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context { get; set; }

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/Rentals


        //POST api/Rentals/
        //Defensive programming has been implemented in this api for good practice if this was a public API.
        [HttpPost]
        public IHttpActionResult CreateRentalOrder(RentalDto newRental)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            if (customer == null)
            {
                var error = new
                {
                    message = "Movie cannot be created, due to propties not filled appropiately",
                    error = ModelState.Values.SelectMany(e => e.Errors.Select(m => m.ErrorMessage))
                }; 
                return BadRequest(error.ToString());
            }

            if(newRental.MovieId.Count == 0)
            {
                return BadRequest("No movie given for the rental order");
            }

            //iterate through each Movie id until all rental.MovieId has been found within the db.
            var movies = _context.Movies.Where(r => newRental.MovieId.Contains(r.Id)).ToList();

            if(newRental.MovieId.Count != movies.Count)
            {
                return BadRequest("One or more movie(s) id is invalid");
            }    

            //task: we want to create rental object for each movie (using domain model)
            foreach(var movie in movies)
            {
                if(movie.StockAvailability == 0)
                {
                    return BadRequest(String.Format("Movie {0} id: {1}: is currently out of stock.",movie.Name ,movie.Id));
                }

                movie.StockAvailability--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);

            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
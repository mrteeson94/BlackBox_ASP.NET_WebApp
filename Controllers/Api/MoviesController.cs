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
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context { get; set; }

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //1.GET List<Movie> GetMovies()
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>));
        }
        //2.GET GetAMovie(int id)
        public IHttpActionResult GetAMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }
        //3. POST CreateMovie()
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                var error = new
                {
                    message = "Movie cannot be created, due to propties not filled appropiately",
                    error = ModelState.Values.SelectMany(e => e.Errors.Select(m => m.ErrorMessage))
                };
                return BadRequest(error.ToString());
            }
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            //assign newly generated id to movieDto
            movieDto.Id = movie.Id;
            return Created(Request.RequestUri + "/" + movie.Id, movieDto);
        }
        //4. PUT EditMovie()
        [HttpPut]
        public IHttpActionResult EditMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
            return Ok(movieDto);
        }
        //5. DELETE RemoveMovie()
        [HttpDelete]
        public IHttpActionResult RemoveMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
           
            if (movie == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using Vividly.DTOs;
using Vividly.Models;

namespace Vividly.Controllers.Api
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        // GET api/movie
        public IHttpActionResult GetMovies()
        {
            var movieInDb = _context.Movies.Include(g => g.Genre).ToList();
            List<MovieDTO> movieDTOs = new List<MovieDTO>();
            foreach (var movie in movieInDb)
            {
                var movieDTO = Mapper.Map<Movie, MovieDTO>(movie);
                movieDTO.ID = movie.ID;
                movieDTOs.Add(movieDTO);

            }
            return Ok(movieDTOs);
        }
        // GET api/movie/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.ID == id);
            if (movie == null)
                return NotFound();
            var movieDTO = Mapper.Map<Movie, MovieDTO>(movie);
            movieDTO.ID = movie.ID;
            return Ok(movieDTO);
        }
        // POST /api/movie
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDTO.ID = movie.ID;
            return Created(new Uri(Request.RequestUri + "/" + movie.ID),movieDTO);
        }
        // PUT /api/movie/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movieInDB = _context.Movies.SingleOrDefault(m => m.ID == id);
            if (movieInDB == null)
                return NotFound();
            Mapper.Map(movieDTO, movieInDB);
            _context.SaveChanges();
            return Ok("Updated");
        }
        // DELETE /api/movie/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.ID == id);
            if (movieInDb == null)
               return BadRequest();
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
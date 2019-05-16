using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vividly.Models;
using Vividly.View_Models;
using System.Data.Entity.Validation;

namespace Vividly.Controllers
{
    public class MovieController : Controller
    {
        ApplicationDbContext _context;
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
            //var Movies = _context.Movies.Include(g=>g.Genre).ToList();

            //var viewModel = new MovieViewModel
            //{
            //    Movies = Movies,
            //};
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.ID == 0)
            {
                movie.DateAdded = DateTime.Now;

                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.ID == movie.ID);
                movieInDb.GenreID = movie.GenreID;
                movieInDb.Name = movie.Name;
                movieInDb.InStock = movie.InStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genresInDb = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genresInDb
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(m => m.ID == id);
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [Route("movie/details/{id}")]
        public ActionResult Details(int id)
        {
            var Movie = _context.Movies.Include(g => g.Genre).Where(i => i.ID == id).FirstOrDefault();
            return View(Movie);
        }
    }
}
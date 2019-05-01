using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vividly.Models;
using Vividly.View_Models;

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
            var Movies = _context.Movies.Include(g=>g.Genre).ToList();

            var viewModel = new MovieViewModel
            {
                Movies = Movies,
            };
            return View(viewModel);

        }
        [Route("movie/details/{id}")]
        public ActionResult Details(int id)
        {
            var Movie = _context.Movies.Include(g => g.Genre).Where(i=>i.ID==id).FirstOrDefault();
            return View(Movie);
        }
    }
}
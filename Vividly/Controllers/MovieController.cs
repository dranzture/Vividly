using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vividly.Models;
using Vividly.View_Models;

namespace Vividly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            var movie = new List<Movie> {
                new Movie { ID = 1, Name = "Avengers: Infinity War", ReleasedDate = new DateTime(2018, 4, 26) },
                new Movie { ID = 2, Name = "Avengers: Endgame", ReleasedDate = new DateTime(2019, 4, 26) }
            };

            var viewModel = new MovieViewModel
            {
                Movies = movie,
            };
            return View(viewModel);

        }
        [Route("movie/released/{year:regex(\\d{4})}/{month:regex():range(1,12)}")]
        public ActionResult ReleaseByYear(int year, int month)
        {
            return Content(year + " / " + month);
        }
    }
}
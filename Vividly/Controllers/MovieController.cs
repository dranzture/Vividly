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
            var movie = new Movie() { ID = 1, Name = "Avengers: Endgame", ReleasedDate = new DateTime(2019, 4, 26) };
            var customers = new List<Customer>
            {
                new Customer{ ID=1, FirstName="Polat", LastName="Coban" },
                new Customer{ ID=2, FirstName="Ashley", LastName="Coban" }
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);

        }
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ReleaseByYear(int year, int month)
        {
            return Content(year + " / " + month);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vividly.Models;

namespace Vividly.View_Models
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}
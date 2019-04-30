using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vividly.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime ReleasedDate { get; set; }
    }
}
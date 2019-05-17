using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vividly.Models
{
    public class Movie
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public byte GenreID { get; set; }

        [Required]
        public int InStock { get; set; }

        public byte NumberAvailable { get; set; }


        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }
    }
}
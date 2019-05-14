using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vividly.Models;

namespace Vividly.DTOs
{
    public class MovieDTO
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public GenreDTO Genre { get; set; }

        [Required]
        public byte GenreID { get; set; }

        [Required]
        public int InStock { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }
    }
}
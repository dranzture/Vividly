﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vividly.Models
{
    public class Rentals
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Movie Movie { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}
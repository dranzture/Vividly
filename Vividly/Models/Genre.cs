using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vividly.Models
{
    public class Genre
    {
        [Required]
        public byte ID { get; set; }

        [StringLength(15)]
        [Required]
        public string Type { get; set; }
    }
}
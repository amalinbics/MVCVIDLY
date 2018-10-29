using Asp.Net_Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp.Net_Identity.DTO
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]      
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1, 20)]       
        public int NoInStock { get; set; }

        public Genre Genre { get; set; }
       
        [Required]
        public byte GenreId { get; set; }
    }
}
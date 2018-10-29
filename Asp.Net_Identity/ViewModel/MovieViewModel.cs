using Asp.Net_Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp.Net_Identity.ViewModel
{
    public class MovieViewModel
    {

        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        public int? NoInStock { get; set; }
      

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        public IEnumerable<Genre> Genres;
    }
}
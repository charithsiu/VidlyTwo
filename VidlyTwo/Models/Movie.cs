using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VidlyTwo.Models
{
    public class Movie
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Movie name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Movie name")]
        public Nullable<DateTime> ReleasedDate { get; set; }
        [Required(ErrorMessage = "Please Enter Movie name")]
        public Nullable<DateTime> DateAdded { get; set; }
        [Required(ErrorMessage = "Please Enter stock value")]
        [Range(1,20,ErrorMessage ="Stock value should be between 1 to 20")]
        public int Stock { get; set; }

        public Genre Genre { get; set; }
        [Required(ErrorMessage = "Please Enter Genre")]
        public int GenreId { get; set; }
        

    }
}
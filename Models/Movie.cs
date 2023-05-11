using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace blackBox.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; } 
        public DateTime DateAdded { get; set; }
        [Required]
        [Display(Name="Number of Stocks")]
        public int NoOfStock { get; set; }

        //Foreign key of Genre
        [Display(Name = "Genre")]
        public Nullable<int> GenreId { get; set; }
        //Reference property
        public virtual Genre Genre { get; set; }
    }
}
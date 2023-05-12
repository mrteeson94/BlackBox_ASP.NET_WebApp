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
        public int Id { get; set; }

        [Required(ErrorMessage ="Please provide the Movie title")]
        [StringLength(255)]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Provide the Movie release date")]
        [Display(Name="Release Date")]
        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}")]
        public DateTime ReleaseDate { get; set; } 

        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage ="Fill in the stock field")]
        [Range(1,20,ErrorMessage ="Please provide stock from 1-20")]
        [Display(Name="Number of Stocks")]
        public int NoOfStock { get; set; }

        [Required(ErrorMessage ="Pick a genre!")]
        //Foreign key of Genre
        [Display(Name = "Genre")]
        public Nullable<int> GenreId { get; set; }
        //Reference property
        public virtual Genre Genre { get; set; }
    }
}
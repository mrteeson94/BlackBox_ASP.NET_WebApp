using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace blackBox.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide the Movie title")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Provide the Movie release date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Fill in the stock field")]
        [Range(1, 20, ErrorMessage = "Please provide stock from 1-20")]
        public int NoOfStock { get; set; }

        [Required(ErrorMessage = "Pick a genre!")]
        //Foreign key of Genre
        public Nullable<int> GenreId { get; set; }
        //Reference property
    }
}
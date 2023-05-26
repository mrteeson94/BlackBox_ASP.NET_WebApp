using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using blackBox.Models;

namespace blackBox.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Please provide stock from 1-20")]
        public int NoOfStock { get; set; }

        [Required]
        //Foreign key of Genre
        public Nullable<int> GenreId { get; set; }
        //Reference property
        public virtual GenreDto Genre { get; set; }

    }
}
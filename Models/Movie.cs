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
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; } 
        public DateTime DateAdded { get; set; }
        [Required]
        public int NoOfStock { get; set; }

        //Foreign key of Genre
        public Nullable<int> GenreId { get; set; }
        //Reference property
        public virtual Genre Genre { get; set; }
    }
}
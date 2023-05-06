using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace blackBox.Models
{
    public class Genre
    {
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }

        [Key]
        public int GenreId { get; set; }

        [Required]
        [StringLength(255)]
        public string GenreTitle { get; set; }

        //reference to Movie
        public virtual ICollection<Movie> Movies { get; set; }

    }
}
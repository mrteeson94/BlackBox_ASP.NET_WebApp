using blackBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blackBox.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}
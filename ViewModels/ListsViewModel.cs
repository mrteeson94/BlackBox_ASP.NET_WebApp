using blackBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blackBox.ViewModels
{
    public class ListsViewModel
    {
        public List<Movie> Movie { get; set; }
        public List<Customer> Customer { get; set; }
    }
}
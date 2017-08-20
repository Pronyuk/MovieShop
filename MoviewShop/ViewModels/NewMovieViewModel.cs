using MoviewShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviewShop.ViewModels
{
    public class NewMovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<MovieGenre> MovieGenre { get; set; }
    }
}
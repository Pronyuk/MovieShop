using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviewShop.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public int NumberInStock { get; set; }
        public MovieGenre Genre { get; set; }
        public int MovieGenreId { get; set; }
    }
}
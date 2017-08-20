using MoviewShop.Models;
using MoviewShop.ViewModels;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviewShop.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult ShowAllMovies()
        {
            var viewModel = new ShowAllMoviesViewModel()
            {
                Movies = _context.Movies.Include((m) => m.Genre).ToList()
            };
            return View(viewModel);
        }

        public ActionResult NewMovie()
        {
            var movieGenre = _context.MovieGenres.ToList();
            var newMovieViewModel = new NewMovieViewModel()
            {
                Movie = new Movie(),
                MovieGenre = movieGenre
            };
            return View(newMovieViewModel);
        }

        public ActionResult MoviePage(int Id)
        {
            var movies = _context.Movies.ToList();
            var movie = movies.SingleOrDefault((c) => c.Id == Id);
            if (movies.Count != 0)
            {
                return View(movie);
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult Save(Movie movie)
        {
            var newMovie = new Movie()
            {
                DateAdded = movie.DateAdded,
                ReleaseDate = movie.ReleaseDate,
                NumberInStock = movie.NumberInStock,
                Name = movie.Name,
                MovieGenreId = movie.MovieGenreId
            };
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
            return RedirectToAction("ShowAllMovies", "Movies");
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex = {0} & sortBy = {1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year}/{month:range(1,12):regex(\\d{2})}")]
        public ActionResult ByReLeaseDate(int year, int month)
        {
            //:regex(\\d{4}):range(1,12)
            return Content(year + "/" + month);
        }
    }
}
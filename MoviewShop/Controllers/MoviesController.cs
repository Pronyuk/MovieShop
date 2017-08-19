using MoviewShop.Models;
using MoviewShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviewShop.Controllers
{
    public class MoviesController : Controller
    {
        List<Movie> movies = new List<Movie>()
        {
            new Movie() { Id = 1, Name = "Incredable" },
            new Movie() { Id = 2, Name = "Best of 5" }
        };

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer>
            {
                new Customer() {Name = "Cust 1" },
                new Customer() {Name = "Cust 2" }
            };
            var viewmodel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewmodel);
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
        public ActionResult ByReLeaseDate( int year, int month)
        {
            //:regex(\\d{4}):range(1,12)
            return Content(year + "/" + month);
        }

        public ActionResult ShowAllMovies()
        {
            var viewModel = new ShowAllMoviesViewModel()
            {
                Movies = movies
            };
            return View(viewModel);
        }

        public ActionResult MoviePage(int Id)
        {
            var movie = movies.FirstOrDefault((c) => c.Id == Id);
            if (movies != null)
            {
                return View(movie);
            }

            else
            {
                return HttpNotFound();
            }
        }
    }
}
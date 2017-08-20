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
                Movies = _context.Movies.Include((m) => m.Genre).ToList()
            };
            return View(viewModel);
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
    }
}
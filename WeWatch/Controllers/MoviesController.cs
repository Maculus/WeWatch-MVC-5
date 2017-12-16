using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeWatch.Models;
using WeWatch.ViewModels;

namespace WeWatch.Controllers
{
    public class MoviesController : Controller
    {

        // Declare Dbset context variable to access database
        private ApplicationDbContext _context;



        // Constructor required for context initialization
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        // To properly dispose of the db context
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Movies/
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }


        // GET: Movies/Detail/id
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }


        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek"};

            var customers = new List<Customer>
            {
                new Customer { Name = "John Brown"},
                new Customer { Name = "Maurice McCrae"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }



        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]  // Attribute Routing for condensed and efficient routes

        public ActionResult MoviesByReleaseDate(int year, int month)
        {
            return Content("The movie year is " + year +" and the month of movie is " + month);
        }

    }
}
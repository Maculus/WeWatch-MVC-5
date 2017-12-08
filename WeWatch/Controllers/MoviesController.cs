using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeWatch.Models;
using WeWatch.ViewModels;

namespace WeWatch.Controllers
{
    public class MoviesController : Controller
    {

        // GET: Movies/
        public ViewResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }


        // GET: Movies/Detail/id
        public ActionResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(m => m.Id == id);

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



        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }
    }
}
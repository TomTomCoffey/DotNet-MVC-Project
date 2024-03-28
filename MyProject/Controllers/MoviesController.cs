using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.ViewModels;


namespace MyProject.Controllers
{
    public class MoviesController : Controller
    {

        public ActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        private List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new() {Id= 1, Name = "Face Off" },
                new() {Id= 2, Name = "Con Air" }
            };
        }
        public IActionResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return View(movie);
        }

        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new() { Name = "Customer 1" },
                new() { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customer = customers
            };

            return View(viewModel);

        }
        public IActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }


}


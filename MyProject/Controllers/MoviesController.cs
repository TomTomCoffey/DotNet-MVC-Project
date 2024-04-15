using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.ViewModels;


namespace MyProject.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies?.ToList();

            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _context.Movies?.SingleOrDefault(c => c.Id == id);

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
        public IActionResult New()
        {
            var genres = _context.Genres?.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genres = genres!
            };

            return View("MoviesForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Movie movie)
        {
            // if (!ModelState.IsValid)
            // {
            //     var viewModel = new NewMovieViewModel
            //     {
            //         Movie = movie,
            //         Genres = _context.Genres?.ToList()
            //     };
            //     Console.WriteLine("Model State is not valid");
            //     return View("MoviesForm", viewModel);
            // }


            if (movie.Id == 0)
            {
                Console.WriteLine("Movie ID is 0");
                movie.DateAdded = DateTime.Now;
                _context.Movies?.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies?.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Genre = movie.Genre;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies?.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
                Genres = _context.Genres?.ToList()
            };

            return View("MoviesForm", viewModel);
        }

        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }


}


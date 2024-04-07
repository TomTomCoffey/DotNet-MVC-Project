using Microsoft.AspNetCore.Mvc;
using MyProject.Models;

namespace MyProject.Controllers.Api
{

    [ApiController]
    [Route("api/[controller]")]

    public class MoviesController : ControllerBase
    {
        private ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            return _context.Movies.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return movie;
        }

        [HttpPost]
        public ActionResult<Movie> CreateMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return movie;
        }

        [HttpPut("{id}")]
        public ActionResult<Movie> UpdateMovie(int id, Movie movie)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            movieInDb.Name = movie.Name;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.DateAdded = movie.DateAdded;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.GenreId = movie.GenreId;

            _context.SaveChanges();

            return movieInDb;
        }

        [HttpDelete("{id}")]
        public ActionResult<Movie> DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return movie;
        }

    }
}
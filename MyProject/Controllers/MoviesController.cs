using Microsoft.AspNetCore.Mvc;
using MyProject.Models;


namespace MyProject.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            return View(movie);

        }
    }
}


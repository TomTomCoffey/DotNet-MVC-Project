using MyProject.Models;
namespace MyProject.ViewModels

{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre>? Genres { get; set; }
        public Movie? Movie { get; set; }
    }
}
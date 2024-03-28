
using MyProject.Models;
using System.Collections.Generic;

namespace MyProject.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie? Movie { get; set; }
        public List<Customer>? Customer { get; set; }
    }
}
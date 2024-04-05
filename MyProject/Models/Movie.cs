

using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        [Display(Name = "Release Date")]
        [RealReleaseDate]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        [NumberofMovies]
        public int NumberInStock { get; set; }


        public Genre? Genre { get; set; }

        public byte GenreId { get; set; }




    }
}

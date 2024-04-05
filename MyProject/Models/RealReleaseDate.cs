
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class RealReleaseDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            if (movie.ReleaseDate == null)
                return new ValidationResult("Release date is required.");

            if (movie.ReleaseDate > DateTime.Now)
                return new ValidationResult("Release date should be less than or equal to today's date.");

            if (movie.ReleaseDate < new DateTime(1888, 1, 1))
                return new ValidationResult("There are no movies that old");

            return ValidationResult.Success;
        }
    }

}
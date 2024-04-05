
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class NumberofMovies : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            if (movie.NumberInStock <= 0)
                return new ValidationResult("Number in stock is required.");


            if (movie.NumberInStock > 20)
                return new ValidationResult("Number in stock should be less than 20.");

            return ValidationResult.Success;
        }
    }
}
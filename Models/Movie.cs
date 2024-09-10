using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MovieList.Models
{
    public class Movie
    {
        // EF Core will configure the database to generate this value
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")] 
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a year.")]
        [Range(1889, 2999, ErrorMessage = "Year must be after 1889.")] 
        public int? Year { get; set; }

        [Required(ErrorMessage = "Please enter a rating.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")] 
        public int? Rating { get; set; }

        // Tying in the Genre entity.
        [Required(ErrorMessage = "Please enter a genre.")] 
        // string.Empty indicates that this is a foreign key field/property(primary key within Genre class).
        public string GenreId { get; set; } = string.Empty; [ValidateNever]
        // Relating the Genre entity to the Movie by coding a property with that entity class as a datatype.
        public Genre Genre { get; set; } = null!;

        // Allowing for the optional slug property.
        public string Slug =>
        Name?.Replace(' ', '-').ToLower() + '-' + Year?.ToString();
    }
}

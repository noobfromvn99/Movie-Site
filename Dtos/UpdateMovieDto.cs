using System.ComponentModel.DataAnnotations;
namespace Movies.Dtos{
    public record UpdateMovieDto{
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(1, 1000)]
        public decimal Price { get; init; }
    }
}
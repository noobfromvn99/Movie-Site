using System.ComponentModel.DataAnnotations;
namespace Movies.Dtos{
    public record CreateMovieDto{
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(1, 1000)]
        public decimal Price { get; init; }
    }
}
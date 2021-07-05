using Movies.Dtos;
using Movies.Entities;
namespace Movies
{
    public static class Extensions
    {
        public static MovieDto AsDto(this Movie movie)
        {
            return new MovieDto
            {
                Id = movie.Id,
                Name = movie.Name,
                Price = movie.Price,
                CreatedDate = movie.CreatedDate
            };
        }
    }
}
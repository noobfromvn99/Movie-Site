using System;
using System.Collections.Generic;
using Movies.Entities;
using System.Linq;

namespace Movies.Repositories
{

    public class InMemMoviesRepository : IMoviesRepository
    {
        private readonly List<Movie> movies = new()
        {
            new Movie { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Movie { Id = Guid.NewGuid(), Name = "Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
            new Movie { Id = Guid.NewGuid(), Name = "Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Movie> GetMovies() { return movies; }

        public Movie GetMovie(Guid id)
        {
            return movies.Where(movie => movie.Id == id).SingleOrDefault();
        }
        public void CreateMovie(Movie movie){
            movies.Add(movie);
        }

        public void UpdateMovie(Movie movie){
            var index = movies.FindIndex(existingMovie => existingMovie.Id == movie.Id);
            movies[index] = movie;
        }
    }
}

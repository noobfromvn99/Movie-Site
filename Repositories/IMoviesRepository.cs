using System;
using Movies.Entities;
using System.Collections.Generic;
namespace Movies.Repositories{
        public interface IMoviesRepository
    {
        Movie GetMovie(Guid id);
        IEnumerable<Movie> GetMovies();
        void CreateMovie(Movie movie);
        void UpdateMovie(Movie movie);
    }
}
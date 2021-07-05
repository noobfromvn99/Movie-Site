using Microsoft.AspNetCore.Mvc;
using System;
using Movies.Repositories;
using System.Collections.Generic;
using Movies.Entities;
using System.Linq;
using Movies.Dtos;
namespace Movies.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepository repository;
        public MoviesController(IMoviesRepository repository)
        {
            this.repository = repository;
        }

        // GET /movies
        [HttpGet]
        public IEnumerable<MovieDto> GetMovies()
        {
            var movies = repository.GetMovies().Select(movie => movie.AsDto());
            return movies;
        }
        // GET /movies/{id}
        [HttpGet("{id}")]
        public ActionResult<MovieDto> GetMovie(Guid id)
        {
            var movie = repository.GetMovie(id);
            if (movie is null)
            {
                return NotFound();
            }
            return movie.AsDto();
        }

        //POST /Movies
        [HttpPost]
        public ActionResult<MovieDto> CreateMovie(CreateMovieDto movieDto)
        {
            Movie movie = new()
            {
                Id = Guid.NewGuid(),
                Name = movieDto.Name,
                Price = movieDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            repository.CreateMovie(movie);

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie.AsDto());
        }

        //PUT /movies/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMovide(Guid id, UpdateMovieDto movieDto)
        {
            var existingMovie = repository.GetMovie(id);
            if (existingMovie is null){
                return NotFound();
            }

            Movie updatedMovie = existingMovie with {
                Name = movieDto.Name,
                Price = movieDto.Price
            };
            repository.UpdateMovie(updatedMovie);

            return NoContent();
        }
    }
}
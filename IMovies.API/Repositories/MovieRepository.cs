using IMovies.API.Context;
using IMovies.API.Domain.Models;
using IMovies.API.DTOs.Movie;
using IMovies.API.Repositories.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace IMovies.API.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationContext _dbContext;
        public MovieRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Add(CreateOrUpdateMovieDto movieDto)
        {
            var movieMap = movieDto.Adapt<Movie>();
            if (movieMap is not null)
            {
                await _dbContext.Movies.AddAsync(movieMap);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<MovieResponseDto> Get(int id)
        {
            var movie = await _dbContext.Movies.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            var moviesMap = movie.Adapt<MovieResponseDto>();

            if (moviesMap is not null)
                return moviesMap;

            return null;
        }

        public async Task<List<MovieResponseDto>> GetAll()
        {
            var movies = await _dbContext.Movies.ToListAsync();
            var moviesMap = movies.Adapt<List<MovieResponseDto>>();

            if (movies.Count > 0)
                return moviesMap;

            return null;
        }

        public async Task<bool> Put(int id, CreateOrUpdateMovieDto movie)
        {
            var movieId = await _dbContext.Movies.Where(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
            if (movieId is null)
                return false;

            var movieMap = movie.Adapt<Movie>();
            if (movieMap is not null)
            {
                movieMap.Id = movieId.Id;
                _dbContext.Update(movieMap);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<bool> Remove(int id)
        {
            var movie = await _dbContext.Movies.Where(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
            if (movie is not null)
            {
                _dbContext.Remove(movie);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}

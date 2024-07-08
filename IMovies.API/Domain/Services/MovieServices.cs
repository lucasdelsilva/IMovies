using IMovies.API.Domain.Services.Interfaces;
using IMovies.API.DTOs.Movie;
using IMovies.API.Repositories.Interfaces;

namespace IMovies.API.Domain.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly IMovieRepository _repository;
        public MovieServices(IMovieRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> AddAsync(CreateOrUpdateMovieDto movieDto)
        {
            return _repository.Add(movieDto);
        }

        public Task<bool> PutAsync(int id, CreateOrUpdateMovieDto movieDto)
        {
            return _repository.Put(id, movieDto);
        }

        public Task<bool> RemoveAsync(int id)
        {
            return _repository.Remove(id);
        }

        public Task<List<MovieResponseDto>> GetAllAsync()
        {
            return _repository.GetAll();
        }

        public Task<MovieResponseDto> GetAsync(int id)
        {
            return _repository.Get(id);
        }
    }
}

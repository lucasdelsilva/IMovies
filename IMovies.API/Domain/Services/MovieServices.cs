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

        public Task<bool> PutAsync(string id, CreateOrUpdateMovieDto movieDto)
        {
            Guid.TryParse(id, out var guidId);
            return _repository.Put(guidId, movieDto);
        }

        public Task<bool> RemoveAsync(string id)
        {
            Guid.TryParse(id, out var guidId);
            return _repository.Remove(guidId);
        }

        public Task<List<MovieResponseDto>> GetAllAsync()
        {
            return _repository.GetAll();
        }

        public Task<MovieResponseDto> GetAsync(string id)
        {
            Guid.TryParse(id, out var guidId);
            return _repository.Get(guidId);
        }
    }
}

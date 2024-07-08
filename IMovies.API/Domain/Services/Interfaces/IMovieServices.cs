using IMovies.API.DTOs.Movie;

namespace IMovies.API.Domain.Services.Interfaces
{
    public interface IMovieServices
    {
        Task<bool> AddAsync(CreateOrUpdateMovieDto movieDto);
        Task<bool> PutAsync(string id, CreateOrUpdateMovieDto movieDto);
        Task<bool> RemoveAsync(string id);
        Task<MovieResponseDto> GetAsync(string id);
        Task<List<MovieResponseDto>> GetAllAsync();
    }
}
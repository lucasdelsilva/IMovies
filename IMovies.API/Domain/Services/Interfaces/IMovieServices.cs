using IMovies.API.DTOs.Movie;

namespace IMovies.API.Domain.Services.Interfaces
{
    public interface IMovieServices
    {
        Task<bool> AddAsync(CreateOrUpdateMovieDto movieDto);
        Task<bool> PutAsync(int id, CreateOrUpdateMovieDto movieDto);
        Task<bool> RemoveAsync(int id);
        Task<MovieResponseDto> GetAsync(int id);
        Task<List<MovieResponseDto>> GetAllAsync();
    }
}
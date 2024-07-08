using IMovies.API.DTOs.Movie;

namespace IMovies.API.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<bool> Add(CreateOrUpdateMovieDto movie);
        Task<bool> Put(Guid id, CreateOrUpdateMovieDto movie);
        Task<bool> Remove(Guid id);
        Task<MovieResponseDto> Get(Guid id);
        Task<List<MovieResponseDto>> GetAll();
    }
}
using IMovies.API.DTOs.Movie;

namespace IMovies.API.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<bool> Add(CreateOrUpdateMovieDto movie);
        Task<bool> Put(int id, CreateOrUpdateMovieDto movie);
        Task<bool> Remove(int id);
        Task<MovieResponseDto> Get(int id);
        Task<List<MovieResponseDto>> GetAll();
    }
}
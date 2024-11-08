using IMovies.Console.Models;

namespace IMovies.Console.Services
{
    public interface IConsoleMovieService
    {
        Task<bool> Add(List<IMovieDetails> movies);
    }
}
using IMovies.Console.Context;
using IMovies.Console.Models;

namespace IMovies.Console.Services
{
    public class ConsoleMovieService : IConsoleMovieService
    {
        private static ConsoleApplicationContext _appDbContext;
        public ConsoleMovieService(ConsoleApplicationContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Add(List<IMovieDetails> movies)
        {
            if (movies.Count > 0)
            {
                try
                {
                    await _appDbContext.IMovieDetails.AddRangeAsync(movies);
                    await _appDbContext.SaveChangesAsync();

                    return true;
                }
                catch (Exception)
                {
                    throw new Exception("Ocorreu algum erro ao cadastrar os filmes!");
                }
            }

            return false;
        }
    }
}
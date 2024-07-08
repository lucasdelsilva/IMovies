using IMovies.API.Domain.Models;

namespace IMovies.API.Domain.Services.Authentication.Token
{
    public interface ITokenServices
    {
        string GenerateToken(User user);
    }
}
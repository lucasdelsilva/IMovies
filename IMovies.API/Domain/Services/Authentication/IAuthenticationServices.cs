using IMovies.API.DTOs;

namespace IMovies.API.Domain.Services.Authentication
{
    public interface IAuthenticationServices
    {
        Task<string> LoginAsync(AuthenticationDto authentication);
    }
}
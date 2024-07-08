using IMovies.API.DTOs.User;

namespace IMovies.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Add(RegisterUserDto user);
    }
}
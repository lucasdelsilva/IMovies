using IMovies.API.DTOs.User;

namespace IMovies.API.Domain.Services.Interfaces
{
    public interface IUserServices
    {
        Task<bool> AddAsync(RegisterUserDto userAddDto);
    }
}
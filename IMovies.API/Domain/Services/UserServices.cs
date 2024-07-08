using IMovies.API.Domain.Services.Interfaces;
using IMovies.API.DTOs.User;
using IMovies.API.Repositories.Interfaces;

namespace IMovies.API.Domain.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository; ;
        }

        public Task<bool> AddAsync(RegisterUserDto userAddDto)
        {
            return _userRepository.Add(userAddDto);
        }
    }
}

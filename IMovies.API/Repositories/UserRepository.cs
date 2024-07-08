using IMovies.API.Context;
using IMovies.API.Domain.Models;
using IMovies.API.DTOs.User;
using IMovies.API.Repositories.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace IMovies.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _dbContext;
        private readonly UserManager<User> _userManager;
        public UserRepository(ApplicationContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<bool> Add(RegisterUserDto user)
        {
            var userMap = user.Adapt<User>();
            if (userMap is not null)
            {
                var result = await _userManager.CreateAsync(userMap, user.Password);
                if (result.Succeeded)
                    return true;
            }
            return false;
        }
    }
}
using IMovies.API.Domain.Models;
using IMovies.API.Domain.Services.Authentication.Token;
using IMovies.API.DTOs;
using Microsoft.AspNetCore.Identity;

namespace IMovies.API.Domain.Services.Authentication
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenServices _tokenServices;

        public AuthenticationServices(SignInManager<User> signInManager, ITokenServices tokenServices)
        {
            _signInManager = signInManager;
            _tokenServices = tokenServices;
        }

        public async Task<string> LoginAsync(AuthenticationDto authentication)
        {
            var result = await _signInManager.PasswordSignInAsync(authentication.UserName, authentication.Password, false, false);
            if (!result.Succeeded)
                throw new ApplicationException("Usuário não autenticado!");

            var user = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName.Equals(authentication.UserName.ToUpper()));

            return _tokenServices.GenerateToken(user);
        }
    }
}

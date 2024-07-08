using FluentValidation;
using IMovies.API.Domain.Services.Authentication;
using IMovies.API.DTOs;
using IMovies.API.DTOs.User;
using IMovies.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMovies.API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticationServices _authenticationService;
        private readonly IUserRepository _userRepository;
        private readonly IValidator<RegisterUserDto> _registerValidator;
        private readonly IValidator<AuthenticationDto> _loginValidator;

        public UserController(IAuthenticationServices authenticationService, IUserRepository userRepository, IValidator<RegisterUserDto> registerValidator, IValidator<AuthenticationDto> loginValidator)
        {
            _authenticationService = authenticationService;
            _userRepository = userRepository;
            _registerValidator = registerValidator;
            _loginValidator = loginValidator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticationDto authentication)
        {
            var validationResult = _loginValidator.Validate(authentication);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var token = await _authenticationService.LoginAsync(authentication);
            return Ok(token);
        }

        [Authorize]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto userAddDto)
        {
            var validationResult = _registerValidator.Validate(userAddDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await _userRepository.Add(userAddDto);
            if (result)
                return Ok(result);

            return BadRequest();
        }
    }
}
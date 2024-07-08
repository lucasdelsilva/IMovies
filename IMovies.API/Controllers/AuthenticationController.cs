using IMovies.API.Domain.Services.Authentication;
using IMovies.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace IMovies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationServices _authenticationService;
        public AuthenticationController(IAuthenticationServices authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthenticationDto authentication)
        {
            var token = await _authenticationService.LoginAsync(authentication);
            return Ok(token);
        }
    }
}

using IMovies.API.DTOs.User;
using IMovies.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IMovies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // POST api/<AutenticationUser>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterUserDto userAddDto)
        {
            var result = await _userRepository.Add(userAddDto);
            if (result)
                return Ok(result);

            return BadRequest();
        }
    }
}
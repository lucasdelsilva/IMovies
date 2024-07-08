using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMovies.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccessController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Autorizado.");
        }
    }
}
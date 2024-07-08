using Microsoft.AspNetCore.Mvc;

namespace IMovies.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccessController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Autorizado.");
        }
    }
}
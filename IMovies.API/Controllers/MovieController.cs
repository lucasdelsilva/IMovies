using FluentValidation;
using IMovies.API.Domain.Services.Interfaces;
using IMovies.API.DTOs.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMovies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieServices _movieServices;
        private readonly IValidator<CreateOrUpdateMovieDto> _validator;
        public MovieController(IMovieServices movieServices, IValidator<CreateOrUpdateMovieDto> validator)
        {
            _movieServices = movieServices;
            _validator = validator;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _movieServices.GetAllAsync();
            if (result is not null)
                return Ok(result);

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _movieServices.GetAsync(id);
            if (result is not null)
                return Ok(result);

            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AdddMovie([FromBody] CreateOrUpdateMovieDto movieDto)
        {
            var validationResult = _validator.Validate(movieDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await _movieServices.AddAsync(movieDto);
            if (result)
                return Ok(result);

            return BadRequest();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] CreateOrUpdateMovieDto moviePutDto)
        {
            var result = await _movieServices.PutAsync(id, moviePutDto);
            if (result)
                return Ok(result);

            return NotFound();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _movieServices.RemoveAsync(id);
            if (result)
                return Ok(result);

            return BadRequest();
        }
    }
}
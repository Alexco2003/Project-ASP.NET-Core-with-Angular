using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models.DTOs.MovieDTOs;
using Project.Services.MovieService;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _MovieService;

        public MovieController(IMovieService MovieService)
        {
            _MovieService = MovieService;
        }

        [HttpGet("GetTop3MoviesFromSubscription")]
        public async Task<IActionResult> GetTop3MoviesAsync(Guid subscriptionId)
        {
            try
            {
                return Ok(await _MovieService.GetTop3MoviesAsync(subscriptionId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetMoviesByDurationFromSubscription")]
        public async Task<IActionResult> GetMoviesByDurationAsync(Guid subscriptionId)
        {
            try
            {
                return Ok(await _MovieService.GetMoviesByDurationAsync(subscriptionId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetTopMovies")]
        public async Task<IActionResult> GetTopAll()
        {
            try
            {
                return Ok(await _MovieService.GetTopAllMoviesAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetMoviesByMPARating")]
        public async Task<IActionResult> GeMoviesByMPARATING(Guid subscriptionId)
        {
            try
            {
                return Ok(await _MovieService.GetMoviesByMPARatingAsync(subscriptionId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetMoviesByMPARating2")]
        public async Task<IActionResult> GeMoviesByMPARATING2(Guid subscriptionId)
        {
            try
            {
                return Ok(await _MovieService.GetMoviesByMPARatingAsync2(subscriptionId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateMovie")]
        public async Task<IActionResult> CreateMovie(MovieCreateDTO Movie)
        {
            try
            {
                await _MovieService.CreateMovie(Movie);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovie(Guid MovieId)
        {
            try
            {
                _MovieService.Delete(MovieId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPatch("UpdateMovie")]
        public IActionResult EditMovie([FromBody] MovieUpdateDTO Movie)
        {
            try
            {
                _MovieService.UpdateMovie(Movie);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

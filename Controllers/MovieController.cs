using CertificateAndTokenApi.DTO;
using CertificateAndTokenApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CertificateAndTokenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieService _movieService { get; }

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Get()
        {
            return Ok(_movieService.GetMovies());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] MovieDto movie)
        {
            return Ok(_movieService.CreateMovie(movie));
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Put([FromBody] MovieDto movie)
        {
            return Ok(_movieService.UpdateMovie(movie));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            return Ok(_movieService.DeleteMovie(id.ToString()));
        }
    }
}

using CertificateAndTokenApi.DTO;
using CertificateAndTokenApi.Interfaces;
using CertificateAndTokenApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CertificateAndTokenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ITokenService _tokenService { get; }
        private IUserService _userService { get; }

        public AuthController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoginDto request)
        {
            if (_userService.CheckLogin(request))
            {
                return Ok(_tokenService.CreateToken(request));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("[action]")]
        public IActionResult Register([FromBody] LoginDto request)
        {
            if (_userService.Register(request))
            {
                return Ok("User was created");
            }
            else
            {
                return BadRequest("User already exists");
            }
        }
    }
}

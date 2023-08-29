using Microsoft.AspNetCore.Mvc;

namespace CertificateAndTokenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] UserPassDTO request)
        {
            var result = new List<KeyValuePair<string, string>>();

            if (request.username == "Mikkel" && request.password == "Mikkel123")
            {
                TokenModel token = JwtManager.Generate();

                return Ok(token);
            }
            else return BadRequest();
        }
    }
}

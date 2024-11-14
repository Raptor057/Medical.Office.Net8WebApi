using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints
{
    [ApiController]
    [Route("[controller]")]
    public class DockerTestController : ControllerBase
    {
        private readonly Random _random;

        public DockerTestController()
        {
            _random = new Random();
        }

        [HttpGet]
        [Route("/api/getrandomnumber")]
        public IActionResult GetRandomNumber()
        {
            int randomNumber = _random.Next();
            return Ok(randomNumber);
        }
    }
}

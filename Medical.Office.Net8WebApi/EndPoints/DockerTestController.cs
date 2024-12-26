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
            var response = new Response("Random number generated successfully", randomNumber, DateTime.UtcNow, DateTime.UtcNow);
            //return Ok(randomNumber);
            return Ok(response);
        }
    }
    public record Response(string Message,int RandomNumber, DateTime TimeStamp, DateTime UtcTimeStamp);
}

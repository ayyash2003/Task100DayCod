using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Net;
using Task1.Model;

namespace Task1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet("/hello")]
        public  ActionResult<string> GetGreeting([FromQuery] string name ="World!")
        {
            string greeting = $"Hello, {name}";

            return Ok(greeting);
        }
        [HttpGet("/info")]
        public ActionResult<Info> GetInfo()
        {
            Header header = new Header
            {
                Accept = Request.Headers["Accept"].ToString(),
                User_Agent = Request.Headers["User-Agent"].ToString()
            };
            var info = new Info
            {
                time = DateTime.Now,
                client_address = HttpContext.Connection.RemoteIpAddress.ToString(),
                host_name = Dns.GetHostName(),
                header = header
            };

            return Ok(info);
        }
    }
}

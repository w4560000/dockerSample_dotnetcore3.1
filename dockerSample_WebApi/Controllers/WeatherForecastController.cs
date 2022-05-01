using dockerSample_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dockerSample_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return new Class1().Test();
        }
    }
}
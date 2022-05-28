using dockerSample_Service;
using dockerSample_WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace dockerSample_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// AppSettings
        /// </summary>
        private readonly AppSettings _appSettings;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public string Get()
        {
            return new Class1().Test();
        }

        [HttpGet(nameof(GetEnv))]
        public string GetEnv()
        {
            return _appSettings.Env;
        }
    }
}
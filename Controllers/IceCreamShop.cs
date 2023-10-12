using IcreCreamShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace IcreCreamShop.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<IceCreamShop> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new IceCreamShop
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }



        [HttpGet(Name = "GetIceCream")]
        public IEnumerable<IcreCreamShop.IceCreamShop> GetIceCream()
        {
            FinalICeCream finalICeCream = new FinalICeCream { };
            finalICeCream.it
            return finalICeCream;

        }

    }
}
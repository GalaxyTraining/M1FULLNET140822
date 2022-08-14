using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public readonly record struct Person(string Name,int Age);

        public struct People
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public People()
            {
                Name = "Jose";
                Address = "Avenida Santa Cruz";
            }
            public People(string name,string add)
            {
                Name = name;
                Address = add;
            }
        }
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
        public IEnumerable<WeatherForecast> Get()
        {
            Person person = new Person("Juan", 34);
            Person person2 = person with { Name = "Piero" };
            People people=new People();
            People people1 = new People("Israel", "av santa mercedes");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
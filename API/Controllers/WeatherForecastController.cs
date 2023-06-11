using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

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
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("Into the Get Method of the WeatherForecast");
        var weatherForecasts = Enumerable.Range(1, 5).Select(index =>
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                TemperatureC = Random.Shared.Next(-20, 55)
            };
            _logger.LogInformation("Generated Infor for Index:{index} , Date:{Date}, TempC:{TemperatureC} , Summary :{Summary}",
            index, weatherForecast.Date, weatherForecast.TemperatureC, weatherForecast.Summary);
            return weatherForecast;
        })
        .ToArray();

        return weatherForecasts;
    }
}

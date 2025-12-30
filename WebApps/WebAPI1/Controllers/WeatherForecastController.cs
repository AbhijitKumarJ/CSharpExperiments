using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebAPI1.Controllers;

[ApiController]
[Route("api/WeatherForecast")]
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

    [Route("GetWeatherForecast")]
    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [Route("HealthCheck")]
    [HttpGet]
    public string HealthCheck()
    {
        return "Healthy: " + DateTime.Now.ToString() + "\n" +
               "Environment: " + Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") + "\n" +
               "Machine Name: " + Environment.MachineName + "\n" +
               "OS Version: " + Environment.OSVersion + "\n" +
               "Processor Count: " + Environment.ProcessorCount + "\n" +
               "Current Directory: " + Environment.CurrentDirectory + "\n" +
               "System Directory: " + Environment.SystemDirectory + "\n" +
               "User Domain Name: " + Environment.UserDomainName + "\n" +
               "User Name: " + Environment.UserName + "\n" + 
               "CLR Version: " + Environment.Version + "\n" + 
               "64 Bit OS: " + Environment.Is64BitOperatingSystem + "\n" +
               "64 Bit Process: " + Environment.Is64BitProcess + "\n" + 
               "Tick Count: " + Environment.TickCount + "\n" +
               "Working Set: " + Environment.WorkingSet + "\n" + 
               "Current Time Zone: " + TimeZoneInfo.Local.DisplayName + "\n" +  
               "UTC Offset: " + TimeZoneInfo.Local.GetUtcOffset(DateTime.Now).ToString() + "\n" + 
               "Weather Types Available: " + string.Join(", ", Summaries);
    }


    [Route("SearchWeatherTypes")]
    [HttpGet]
    public JObject SearchWeatherTypes([FromQuery] string filter="")
    {
        var results = FilterWeatherTypes(filter);
        return new JObject
        {
            ["SearchTerm"] = filter,
            ["Results"] = new JArray(results)
        };
    }

    private IEnumerable<string> FilterWeatherTypes(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return Summaries;
        }

        return Summaries.Where(s => s.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }
}

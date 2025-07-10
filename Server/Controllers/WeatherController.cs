using Microsoft.AspNetCore.Mvc;
using GreensProPWA.Server.Services;
namespace GreensProPWA.Server.Controllers;


[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly WeatherService _weatherService;

    public WeatherController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet("{city}")]
    public async Task<IActionResult> Get(string city)
    {
        var result = await _weatherService.GetWeatherAsync(city);
        if (result == null) return NotFound();
        return Ok(result);
    }
}

using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
namespace GreensProPWA.Server.Services;
public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public WeatherService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _apiKey = config["WeatherSettings:OpenWeatherApiKey"];
    }

    public async Task<WeatherApiResponse?> GetWeatherAsync(string city)
    {
        try
        {
            var url = $"http://api.weatherapi.com/v1/current.json?key={_apiKey}&q={city}";
            var currentWeather = await _httpClient.GetFromJsonAsync<WeatherApiResponse>(url);
            return currentWeather;
        }
        catch
        {
            return null;
        }
    }
}

public class WeatherApiResponse
{
    public Location location { get; set; }
    public Current current { get; set; }
}

public class Location
{
    public string name { get; set; }
    public string region { get; set; }
    public string country { get; set; }
    public double lat { get; set; }
    public double lon { get; set; }
    public string tz_id { get; set; }
    public long localtime_epoch { get; set; }
    public string localtime { get; set; }
}

public class Current
{
    public long last_updated_epoch { get; set; }
    public string last_updated { get; set; }
    public double temp_c { get; set; }
    public double temp_f { get; set; }
    public int is_day { get; set; }
    public Condition condition { get; set; }
    public double wind_mph { get; set; }
    public double wind_kph { get; set; }
    public int wind_degree { get; set; }
    public string wind_dir { get; set; }
    public double pressure_mb { get; set; }
    public double pressure_in { get; set; }
    public double precip_mm { get; set; }
    public double precip_in { get; set; }
    public int humidity { get; set; }
    public int cloud { get; set; }
    public double feelslike_c { get; set; }
    public double feelslike_f { get; set; }
    public double windchill_c { get; set; }
    public double windchill_f { get; set; }
    public double heatindex_c { get; set; }
    public double heatindex_f { get; set; }
    public double dewpoint_c { get; set; }
    public double dewpoint_f { get; set; }
    public double vis_km { get; set; }
    public double vis_miles { get; set; }
    public double uv { get; set; }
    public double gust_mph { get; set; }
    public double gust_kph { get; set; }
    public AirQuality air_quality { get; set; }
}

public class Condition
{
    public string text { get; set; }
    public string icon { get; set; }
    public int code { get; set; }
}

public class AirQuality
{
    public double co { get; set; }
    public double no2 { get; set; }
    public double o3 { get; set; }
    public double so2 { get; set; }
    public double pm2_5 { get; set; }
    public double pm10 { get; set; }
    public int us_epa_index { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("gb-defra-index")]
    public int gb_defra_index { get; set; }
}

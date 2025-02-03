using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WeatherApi.Models;

namespace WeatherApi.Controllers;

[Route("api/weather")]
[ApiController]
public class WeatherController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public WeatherController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet("{city}")]
    public async Task<IActionResult> GetWeather(string city)
    {
        const string apiKey = "0aa7e82eceb42a9d2aab4da21df1efeb";
        var apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

        try
        {
            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                return NotFound($"Kunne ikke hente værdata for {city}.");
            }

            var json = await response.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<WeatherApiResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var result = new WeatherData
            {
                Temperature = weatherData.Main.Temp,
                Description = weatherData.Weather.Length > 0
                    ? weatherData.Weather[0].Description
                    : "Ingen beskrivelse tilgjengelig.",
                FeelsLike = weatherData.Main.FeelsLike,
                Humidity = weatherData.Main.Humidity,
                WindSpeed = weatherData.Wind.Speed,
                WindDirection = weatherData.Wind.Deg,
                City = weatherData.Name,
                Condition = weatherData.Weather.Length > 0
                    ? Enum.TryParse(weatherData.Weather[0].Main, true, out WeatherCondition parsedCondition)
                        ? parsedCondition
                        : WeatherCondition.Other
                    : WeatherCondition.Other,
            };

            return Ok(result);
        }
        catch
        {
            return StatusCode(500, "Noe gikk galt med værforespørselen.");
        }
    }
}
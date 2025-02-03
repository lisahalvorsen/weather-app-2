namespace WeatherApi.Models;

public class WeatherApiResponse
{
    public required MainData Main { get; init; }
    public required WeatherInfo[] Weather { get; init; }
    public required WindData Wind { get; init; }
    public required string Name { get; init; }
}
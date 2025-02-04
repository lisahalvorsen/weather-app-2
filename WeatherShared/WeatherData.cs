namespace WeatherShared;

public class WeatherData
{
    public required string City { get; init; }
    public required string Description { get; init; }
    public float Temperature { get; init; }
    public float FeelsLike { get; init; }
    public float Humidity { get; init; }
    public float WindSpeed { get; init; }
    public float WindDirection { get; init; }
    public WeatherCondition Condition { get; init; }
}
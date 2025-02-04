namespace WeatherShared;
using System.Text.Json.Serialization;

public class MainData
{
    public float Temp { get; set; }
    [JsonPropertyName("feels_like")] public float FeelsLike { get; set; }
    public float Humidity { get; set; }
}
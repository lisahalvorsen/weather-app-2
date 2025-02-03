namespace WeatherApi.Controllers;

public class WeatherFormat
{
    public static WeatherCondition MapWeatherCondition(string apiCondition)
    {
        return Enum.TryParse(apiCondition, true, out WeatherCondition condition)
            ? condition
            : WeatherCondition.Other;
    }

}
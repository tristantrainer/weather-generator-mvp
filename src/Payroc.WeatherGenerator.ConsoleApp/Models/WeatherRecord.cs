namespace Payroc.WeatherGenerator.ConsoleApp.Models;

public class WeatherRecord
{
    public required DateTime Timestamp { get; init; }
    public required WeatherInformation[] Information { get; init; }
}

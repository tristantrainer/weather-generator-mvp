namespace Payroc.WeatherGenerator.ConsoleApp.Models;

public class WeatherInformation
{
    public required double Latitude { get; init; }
    public required double Longitude { get; init; }
    public required Temperature Temperature { get; init; }
    public required Wind Wind { get; init; }
    public required int PrecipitationChancePercentage { get; init; }
}

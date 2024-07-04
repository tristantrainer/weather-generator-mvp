using Payroc.WeatherGenerator.ConsoleApp.Extensions;
using Payroc.WeatherGenerator.ConsoleApp.Models;

namespace Payroc.WeatherGenerator.ConsoleApp.Services;

public class WeatherForecastService
{
    private const int HoursInADay = 24;
    private const int MinimumInformationPerRecord = 1;
    private static readonly string[] _principalDirections = ["N", "S", "E", "W", "NE", "NW", "SE", "SW"];
    private static readonly string[] _temperatureUnits = ["C", "F"];

    public static WeatherRecord[] Generate(DateTime start, int numberOfDays, TimeSpan interval) {
        var length = numberOfDays * HoursInADay;

        var series = Enumerable
            .Range(0, length)
            .Select((offset) => start.Add(interval * offset))
            .ToArray();

        var random = new Random();

        return series
            .Select((timestamp) => new WeatherRecord {
                Timestamp = timestamp,
                Information = Enumerable
                    .Range(MinimumInformationPerRecord, random.Next(10))
                    .Select((index) => GenerateRandomWeatherInformation())
                    .ToArray()
            })
            .ToArray();
    }

    private static WeatherInformation GenerateRandomWeatherInformation() {
        var random = new Random();

        return new WeatherInformation {
            Latitude = random.NextDouble(-90, 90),
            Longitude = random.NextDouble(-180, 180),
            Temperature = new Temperature {
                Value = random.NextDouble(-50, 70),
                Unit = _temperatureUnits.Sample(),
            },
            Wind = new Wind {
                Speed = new Speed {
                    Value = random.NextDouble(0, 200),
                    Unit = "km/h"
                },
                Direction = _principalDirections.Sample(),
            },
            PrecipitationChancePercentage = random.Next(0, 100)
        };
    }
}

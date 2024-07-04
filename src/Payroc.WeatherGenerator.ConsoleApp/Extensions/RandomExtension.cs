namespace Payroc.WeatherGenerator.ConsoleApp.Extensions;

public static class RandomExtension
{
    public static double NextDouble(this Random random, double min, double max) 
    {
        return min + (random.NextDouble() * (max - min));
    }
}

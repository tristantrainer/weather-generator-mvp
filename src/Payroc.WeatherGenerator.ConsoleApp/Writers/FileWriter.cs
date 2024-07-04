using Payroc.WeatherGenerator.ConsoleApp.Models;

namespace Payroc.WeatherGenerator.ConsoleApp.Writers;

public class FileWriter
{
    private const string TabDelimiter = "\t";

    public static void WriteTabDelimitedWISFile(string outputFilePath, WeatherRecord[] records) 
    {
        using StreamWriter writer = new(outputFilePath);

        foreach(var record in records) 
        {
            writer.WriteLine(record.Timestamp.ToString("yyyy-MM-dd HH:mm'UTC'"));

            foreach(var row in record.Information) 
            {
                string[] data = [
                    String.Format("{0:F6}", row.Longitude), 
                    String.Format("{0:F6}", row.Latitude), 
                    String.Format("{0:F1}", row.Temperature.Value),
                    row.Temperature.Unit,
                    String.Format("{0:F1}", row.Wind.Speed.Value),
                    row.Wind.Speed.Unit,
                    row.Wind.Direction,
                    row.PrecipitationChancePercentage.ToString(),
                ];

                writer.WriteLine(string.Join(TabDelimiter, data));
            }   
        }
    }
}

// See https://aka.ms/new-console-template for more information
using Payroc.WeatherGenerator.ConsoleApp.Extensions;
using Payroc.WeatherGenerator.ConsoleApp.Models;
using Payroc.WeatherGenerator.ConsoleApp.Services;
using Payroc.WeatherGenerator.ConsoleApp.Writers;

Console.WriteLine("Hello, World!");

var startTime = DateTime.UtcNow.AsOfPreviousHour();
var numberOfDays = 7;
var recordInterval = TimeSpan.FromHours(1);
var outputFilePath = @"** Choose a suitable file path **";

var weatherForecast = WeatherForecastService.Generate(startTime, numberOfDays, recordInterval);

FileWriter.WriteTabDelimitedWISFile(outputFilePath, weatherForecast);
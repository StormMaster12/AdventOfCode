using System;
using System.IO;
using System.Linq;
using AdventOfCode.Business.Services.Implementations;
using AdventOfCode.Business.Services.Interfaces;
using AdventOfCode.Year2019.Implementations;
using AdventOfCode.Year2019.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace AdventOfCode.Year2019
{
    class Program
    {
        static void Main(string[] args)
        {
            IFileProvider provider = new PhysicalFileProvider(Directory.GetCurrentDirectory());

            var serviceProvider = new ServiceCollection()
                .AddSingleton(provider)
                .AddTransient<IFileReader, FileReader>()
                .AddTransient<IFuelCounterUpper, FuelCounterUpper>()
                .AddTransient<IShipComputer, ShipComputer>()
                .BuildServiceProvider();

            var fileReader = serviceProvider.GetService<IFileReader>();
            var fuelCounterUpper = serviceProvider.GetService<IFuelCounterUpper>();
            var shipComputer = serviceProvider.GetService<IShipComputer>();

            var day1FileResult = fileReader.ReadFileByLineToNumberList("Day_1.txt");
            var day2FileResult = fileReader.ReadFileToNumberListBySeperator("Day_2.txt", ",");

            var moduleFuelCount = fuelCounterUpper.GetRequiredFuleForMultipleModules(day1FileResult);
            var moduleFuelCountWithFuel = fuelCounterUpper.GetRequiredFuleForAllModulesAndFuel(day1FileResult);

            var gravityAssistResult = shipComputer.ComputeIntCode(day2FileResult.ToArray());

            Console.WriteLine("Day 1");
            Console.WriteLine($"Fuel Counter Upper: {moduleFuelCount}");
            Console.WriteLine($"Fuel Counter Upper With Fuel: {moduleFuelCountWithFuel}");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Day 2");
            Console.WriteLine($"Gravity Assist Result: {gravityAssistResult[0]}");
            Console.ReadLine();
        }
    }
}

using System;
using System.IO;
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
                .BuildServiceProvider();

            var fileReader = serviceProvider.GetService<IFileReader>();
            var fuelCounterUpper = serviceProvider.GetService<IFuelCounterUpper>();

            var fileResult = fileReader.ReadFileByLineToNumberList("Day_1.txt");

            var moduleFuelCount = fuelCounterUpper.GetRequiredFuleForMultipleModules(fileResult);
            var moduleFuelCountWithFuel = fuelCounterUpper.GetRequiredFuleForAllModulesAndFuel(fileResult);

            Console.WriteLine($"Fuel Counter Upper: {moduleFuelCount}");
            Console.WriteLine($"Fuel Counter Upper With Fuel: {moduleFuelCountWithFuel}");
            Console.ReadLine();
        }
    }
}

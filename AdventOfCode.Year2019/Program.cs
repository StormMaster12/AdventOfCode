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
                .AddTransient<IFuelManagementSystem, FuelManagementSystem>()
                .AddTransient<IShipComputer, ShipComputer>()
                .AddTransient<IPasswordValidator, PasswordValidator>()
                .AddTransient<IPasswordGenerator, PasswordGenerator>()
                .AddTransient<IOrbitalMapFacility, OrbitalMapFacility>()
                .BuildServiceProvider();

            var fileReader = serviceProvider.GetService<IFileReader>();
            var fuelCounterUpper = serviceProvider.GetService<IFuelManagementSystem>();
            var shipComputer = serviceProvider.GetService<IShipComputer>();
            var passwordGenerator = serviceProvider.GetService<IPasswordGenerator>();
            var orbitalMapFacility = serviceProvider.GetService<IOrbitalMapFacility>();

            var day1FileResult = fileReader.ReadFileByLineToNumberList("PuzzleInputs/Day_1.txt");
            var day2FileResult = fileReader.ReadFileToNumberListBySeperator("PuzzleInputs/Day_2.txt", ",");
            var day3FileResult = fileReader.ReadFileToVectorLists("PuzzleInputs/Day_3.txt", ",");
            var day5FileResult = fileReader.ReadFileToNumberListBySeperator("PuzzleInputs/Day_5.txt", ",");
            var day6FileResult = fileReader.ReadFileToValueTuple("PuzzleInputs/Day_6.txt", ")");

            var moduleFuelCount = fuelCounterUpper.GetRequiredFuleForMultipleModules(day1FileResult);
            var moduleFuelCountWithFuel = fuelCounterUpper.GetRequiredFuleForAllModulesAndFuel(day1FileResult);

            var gravityAssistResult = shipComputer.ComputeIntCode(day2FileResult.ToArray());
            var verbAndNounResult = shipComputer.ComputeIntCodeSpecificValue(day2FileResult.ToArray(), 19690720);

            var closestCrossing = fuelCounterUpper.GetFrontPanelWiresClosestCrossingPoint(day3FileResult.ElementAt(0), day3FileResult.ElementAt(1));
            var shortestWire = fuelCounterUpper.GetFrontPanelWiresShortestPathCrossingPoint(day3FileResult.ElementAt(0),day3FileResult.ElementAt(1));

            var numberOfValidPasswords = passwordGenerator.FindValidPasswords(165432, 707912);
            var numberOfValidPasswordsNoLargeGroupsOfNumbers = passwordGenerator.FindValidPasswordsNoLargeGroupsOfNumbers(165432, 707912);

            //var diagnosticProgram = shipComputer.ComputeIntCode(day5FileResult.ToArray(),1);

            var numberOfOrbits = orbitalMapFacility.CalculateOrbits(day6FileResult.ToList());
            var numberOfTransfers = orbitalMapFacility.CalculateOrbitalTransfers(day6FileResult.ToList(), "YOU", "SAN");

            Console.WriteLine("Day 1");
            Console.WriteLine($"Fuel Counter Upper: {moduleFuelCount}");
            Console.WriteLine($"Fuel Counter Upper With Fuel: {moduleFuelCountWithFuel}");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Day 2");
            Console.WriteLine($"Gravity Assist Result: {gravityAssistResult[0]}");
            Console.WriteLine($"Verb: {verbAndNounResult[1]}, Noun: {verbAndNounResult[2]}");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Day 3");
            Console.WriteLine($"Closest Crossing Point: {closestCrossing}");
            Console.WriteLine($"Shortest Wire: {shortestWire}");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Day 4");
            Console.WriteLine($"Number of Valid Passwords: {numberOfValidPasswords}");
            Console.WriteLine($"Number of Valid Passwords No Large Groups of Numbers: {numberOfValidPasswordsNoLargeGroupsOfNumbers}");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Day 5");
            Console.WriteLine($"Diagnostic Code: {123}");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Day 6");
            Console.WriteLine($"Number Of Orbits: {numberOfOrbits}");
            Console.WriteLine($"Number Of Transfers: {numberOfTransfers}");
            Console.ReadLine();
        }
    }
}

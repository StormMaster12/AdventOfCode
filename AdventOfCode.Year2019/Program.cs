using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Business.Services.Implementations;
using AdventOfCode.Business.Services.Interfaces;
using AdventOfCode.Year2019.Implementations;
using AdventOfCode.Year2019.Implementations.ShipComputer;
using AdventOfCode.Year2019.Interfaces;
using AdventOfCode.Year2019.Interfaces.ShipComputer;
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
                .AddTransient<ISpaceImageFormat, SpaceImageFormat>()
                .AddTransient<IAmplifierCircuit, AmplifierCircuit>()
                .BuildServiceProvider();

            var fileReader = serviceProvider.GetService<IFileReader>();
            var fuelCounterUpper = serviceProvider.GetService<IFuelManagementSystem>();
            var shipComputer = serviceProvider.GetService<IShipComputer>();
            var passwordGenerator = serviceProvider.GetService<IPasswordGenerator>();
            var orbitalMapFacility = serviceProvider.GetService<IOrbitalMapFacility>();
            var spaceImageFormat = serviceProvider.GetService<ISpaceImageFormat>();
            var amplifierCircuit = serviceProvider.GetService<IAmplifierCircuit>();

            var day1FileResult = fileReader.ReadFileByLineToNumberList("PuzzleInputs/Day_1.txt");
            var day2FileResult = fileReader.ReadFileToNumberListBySeperator("PuzzleInputs/Day_2.txt", ",");
            var day3FileResult = fileReader.ReadFileToVectorLists("PuzzleInputs/Day_3.txt", ",");
            var day5FileResult = fileReader.ReadFileToNumberListBySeperator("PuzzleInputs/Day_5.txt", ",");
            var day6FileResult = fileReader.ReadFileToValueTuple("PuzzleInputs/Day_6.txt", ")");
            var day7FileResult = fileReader.ReadFileToNumberListBySeperator("PuzzleInputs/Day_7.txt", ",");
            var day8FileResult = fileReader.ReadFileToIntArray("PuzzleInputs/Day_8.txt");

            var moduleFuelCount = fuelCounterUpper.GetRequiredFuleForMultipleModules(day1FileResult);
            var moduleFuelCountWithFuel = fuelCounterUpper.GetRequiredFuleForAllModulesAndFuel(day1FileResult);

            Console.WriteLine("Day 1");
            Console.WriteLine($"Fuel Counter Upper: {moduleFuelCount}");
            Console.WriteLine($"Fuel Counter Upper With Fuel: {moduleFuelCountWithFuel}");
            Console.WriteLine("-----------------------------");

            var gravityAssistResult = shipComputer.ComputeIntCode(day2FileResult.ToArray(), out var a);
            var verbAndNounResult = shipComputer.ComputeIntCodeSpecificValue(day2FileResult.ToArray(), 19690720);

            Console.WriteLine("Day 2");
            Console.WriteLine($"Gravity Assist Result: {gravityAssistResult[0]}");
            Console.WriteLine($"Verb: {verbAndNounResult[1]}, Noun: {verbAndNounResult[2]}");
            Console.WriteLine("-----------------------------");

            var closestCrossing = fuelCounterUpper.GetFrontPanelWiresClosestCrossingPoint(day3FileResult.ElementAt(0), day3FileResult.ElementAt(1));
            var shortestWire = fuelCounterUpper.GetFrontPanelWiresShortestPathCrossingPoint(day3FileResult.ElementAt(0), day3FileResult.ElementAt(1));

            Console.WriteLine("Day 3");
            Console.WriteLine($"Closest Crossing Point: {closestCrossing}");
            Console.WriteLine($"Shortest Wire: {shortestWire}");
            Console.WriteLine("-----------------------------");

            var numberOfValidPasswords = passwordGenerator.FindValidPasswords(165432, 707912);
            var numberOfValidPasswordsNoLargeGroupsOfNumbers = passwordGenerator.FindValidPasswordsNoLargeGroupsOfNumbers(165432, 707912);

            Console.WriteLine("Day 4");
            Console.WriteLine($"Number of Valid Passwords: {numberOfValidPasswords}");
            Console.WriteLine($"Number of Valid Passwords No Large Groups of Numbers: {numberOfValidPasswordsNoLargeGroupsOfNumbers}");
            Console.WriteLine("-----------------------------");

            shipComputer.ComputeIntCode(day5FileResult.ToArray(),out var result, 1);
            shipComputer.ComputeIntCode(day5FileResult.ToArray(), out var thermalRadiatorsDiagnosticCode, 5);

            Console.WriteLine("Day 5");
            Console.WriteLine($"Diagnostic Code: {result}");
            Console.WriteLine($"Thermal Radiators Diagnostic Code: {thermalRadiatorsDiagnosticCode}");
            Console.WriteLine("-----------------------------");

            var numberOfOrbits = orbitalMapFacility.CalculateOrbits(day6FileResult.ToList());
            var numberOfTransfers = orbitalMapFacility.CalculateOrbitalTransfers(day6FileResult.ToList(), "YOU", "SAN");

            Console.WriteLine("Day 6");
            Console.WriteLine($"Number Of Orbits: {numberOfOrbits}");
            Console.WriteLine($"Number Of Transfers: {numberOfTransfers}");
            Console.WriteLine("-----------------------------");

            var maxAmplification = amplifierCircuit.CalculateHighestAmplification(day7FileResult.ToArray(), false);
            var feedbackAmplification = amplifierCircuit.CalculateHighestAmplification(day7FileResult.ToArray(), true);

            Console.WriteLine("Day 7");
            Console.WriteLine($"Highest Ammplification: {maxAmplification}");
            Console.WriteLine($"Feedback Ammplification: {feedbackAmplification}");
            Console.WriteLine("-----------------------------");

            var image = spaceImageFormat.DecodeImage(day8FileResult.ToList(), 25, 6);
            var imageCheck = spaceImageFormat.CheckCorruptedImage(image);

            Console.WriteLine("Day 8");
            Console.WriteLine($"Image Corruption Check: {imageCheck}");
            spaceImageFormat.BuildImage(image);
            Console.ReadLine();
        }
    }
}

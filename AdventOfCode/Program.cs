using System;
using AdventOfCode.Year2017.Implementations;
using AdventOfCode.Year2017.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Linq;
using AdventOfCode.Business.Services.Implementations;
using AdventOfCode.Business.Services.Interfaces;

namespace AdventOfCode.Year2017
{
    class Program
    {
        static void Main(string[] args)
        {
            IFileProvider provider = new PhysicalFileProvider(Directory.GetCurrentDirectory());

            var serviceProvider = new ServiceCollection()
                .AddSingleton(provider)
                .AddTransient<IFileReader, FileReader>()
                .AddTransient<ICaptcha, Captcha>()
                .BuildServiceProvider();

            var fileReader = serviceProvider.GetService<IFileReader>();
            var captcha = serviceProvider.GetService<ICaptcha>();

            var fileResult = fileReader.ReadFileToIntArray("Day1_Data.txt").ToList();
            var captchaMatchSumResult = captcha.GetSumOfNumbersMatchingNextInSequence(fileResult);
            var captchaMiddleSumResult = captcha.SumNumbersThatAreHalfWayAroundList(fileResult);

            Console.WriteLine("Captcha Matching Sum Result: " + captchaMatchSumResult);
            Console.WriteLine("Captcha Middle Sum Result: " + captchaMiddleSumResult);
            Console.ReadLine();
        }
    }
}

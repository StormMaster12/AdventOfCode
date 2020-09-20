using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using AdventOfCode.Business.Enums;
using AdventOfCode.Business.Extensions;
using AdventOfCode.Business.Services.Interfaces;
using Microsoft.Extensions.FileProviders;

namespace AdventOfCode.Business.Services.Implementations
{
    public class FileReader : IFileReader
    {
        private readonly IFileProvider _fileProvider;

        public FileReader(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public IEnumerable<double> ReadFileToIntArray(string input)
        {
            string fileResult = "";

            var fileInfo = _fileProvider.GetFileInfo(input);

            using (var stream = fileInfo.CreateReadStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    fileResult = reader.ReadToEnd();
                }
            }

            return ConvertStringToIntArray(fileResult);
        }

        public IEnumerable<int> ReadFileByLineToNumberList(string input)
        {
            var fileInfo = _fileProvider.GetFileInfo(input);
            var numberList = new List<int>();

            using (var stream = fileInfo.CreateReadStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        var fileIne = reader.ReadLine();
                        numberList.Add(int.Parse(fileIne));
                    }
                }
            }

            return numberList;
        }

        public IEnumerable<int> ReadFileToNumberListBySeperator(string input, string separator)
        {
            var fileInfo = _fileProvider.GetFileInfo(input);
            var numberList = new List<int>();

            using (var stream = fileInfo.CreateReadStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var fileOutPut = reader.ReadToEnd();
                    numberList = fileOutPut.Split(separator).Select(int.Parse).ToList();
                }
            }

            return numberList;
        }

        public IEnumerable<double> ReadFileToNumberListBySeperatorDouble(string input, string separator)
        {
            var fileInfo = _fileProvider.GetFileInfo(input);
            var numberList = new List<double>();

            using (var stream = fileInfo.CreateReadStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var fileOutPut = reader.ReadToEnd();
                    numberList = fileOutPut.Split(separator).Select(double.Parse).ToList();
                }
            }

            return numberList;
        }

        private IEnumerable<double> ConvertStringToIntArray(string stringNumbers)
        {
            var fileResultChar = stringNumbers.ToCharArray();

            return fileResultChar.Select(char.GetNumericValue);
        }

        public IEnumerable<IEnumerable<string>> ReadFileToVectorLists(string input, string separator)
        {
            var fileInfo = _fileProvider.GetFileInfo(input);
            var listOfVectorLists = new List<IEnumerable<string>>();

            using (var stream = fileInfo.CreateReadStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        var fileOutPut = reader.ReadLine();
                        listOfVectorLists.Add(fileOutPut.Split(separator));
                    }
                }
            }

            return listOfVectorLists;
        }

        public IEnumerable<(string parent, string body)> ReadFileToValueTuple(string input, string separator)
        {
            var fileInfo = _fileProvider.GetFileInfo(input);
            var valueTuples = new List<(string parent, string body)>();

            using (var stream = fileInfo.CreateReadStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        var fileOutPut = reader.ReadLine();
                        var splitString = fileOutPut.Split(separator);
                        valueTuples.Add((parent: splitString[0], body: splitString[1]));
                    }
                }
            }

            return valueTuples;
        }
    }
}
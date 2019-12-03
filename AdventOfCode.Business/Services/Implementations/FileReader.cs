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

        private IEnumerable<double> ConvertStringToIntArray(string stringNumbers)
        {
            var fileResultChar = stringNumbers.ToCharArray();

            return fileResultChar.Select(char.GetNumericValue);
        }

        public IEnumerable<IEnumerable<Vector2>> ReadFileToVectorLists(string input, string separator)
        {
            var fileInfo = _fileProvider.GetFileInfo(input);
            var listOfVectorLists = new List<IEnumerable<Vector2>>();

            using (var stream = fileInfo.CreateReadStream())
            {
                using (var reader = new StreamReader(stream))
                {

                    while (!reader.EndOfStream)
                    {
                        var fileOutPut = reader.ReadLine();
                        listOfVectorLists.Add(CreateVectorList(fileOutPut, separator));
                    }
                }
            }

            return listOfVectorLists;
        }

        private IEnumerable<Vector2> CreateVectorList(string input, string separator)
        {
            var regex = new Regex(@"([a-zA-Z]+)(\d+)");
            var vectorList = new List<Vector2>();
            var numberList = input.Split(separator);

            foreach (var s in numberList)
            {
                var result = regex.Match(s);

                var alphaPart = result.Groups[1].Value;
                var numberPart = int.Parse(result.Groups[2].Value);
                vectorList.Add(CreateVector(alphaPart, numberPart));
            }

            return vectorList;
        }

        private Vector2 CreateVector(string direction, int value)
        {
            var directionEnum = direction.GetValueFromDescription<VectorDirectionEnum>();

            return directionEnum switch
            {
                VectorDirectionEnum.Right => new Vector2(value *-1, 0),
                VectorDirectionEnum.Up => new Vector2(0, value),
                VectorDirectionEnum.Left => new Vector2(value, 0),
                VectorDirectionEnum.Down => new Vector2(0 , value * -1),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
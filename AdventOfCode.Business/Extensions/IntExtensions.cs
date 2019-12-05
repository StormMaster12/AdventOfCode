using System.Collections.Generic;

namespace AdventOfCode.Business.Extensions
{
    public static class IntExtensions
    {
        public static IEnumerable<int> ConvertIntToEnumerable(this int input)
        {
            var listOfInts = new List<int>();
            while (input > 0)
            {
                listOfInts.Add(input % 10);
                input = input / 10;
            }

            listOfInts.Reverse();
            return listOfInts;
        }
    }
}
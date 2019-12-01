using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Year2017.Interfaces;

namespace AdventOfCode.Year2017.Implementations
{
    public class Captcha : ICaptcha
    {
        public double GetSumOfNumbersMatchingNextInSequence(IEnumerable<double> data)
        {
            var previousNumber = 0d;
            var sum = 0d;
            foreach (var number in data)
            {
                if (number == previousNumber)
                    sum += number;

                previousNumber = number;
            }

            if (data.First() == data.Last())
                sum += data.Last();

            return sum;
        }

        public double SumNumbersThatAreHalfWayAroundList(IEnumerable<double> data)
        {
            var sum = 0d;
            var dataList = data.ToList();
            var doubleData = dataList.Concat(dataList);

            for (int i = 0; i < dataList.Count; i++)
            {
                var value = dataList[i];
                var halfwayNumber = i + (dataList.Count / 2);
                if (value == doubleData.ElementAt(halfwayNumber))
                {
                    sum += value;
                }
            }

            return sum;
        }
    }
}
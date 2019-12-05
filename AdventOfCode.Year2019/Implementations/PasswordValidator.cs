using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Business.Extensions;
using AdventOfCode.Year2019.Interfaces;

namespace AdventOfCode.Year2019.Implementations
{
    public class PasswordValidator : IPasswordValidator
    {
        public bool Validate(in int input, int minSizeofGroup = 2, bool limitGroupSizeToMinSize = false)
        {
            var numbers = input.ConvertIntToEnumerable().ToList();

            if (numbers.Count() != 6)
                return false;

            var previousNumber = 0;
            var numberPresentCount = new Dictionary<int, int>();
            var foundPair = false;

            foreach (var number in numbers)
            {
                //Numbers Must Increase
                if (previousNumber > number)
                {
                    return false;
                }

                if (!numberPresentCount.TryAdd(number, 1))
                {
                    numberPresentCount[number] += 1;
                }

                previousNumber = number;
            }

            return limitGroupSizeToMinSize ? numberPresentCount.ContainsValue(minSizeofGroup) :  numberPresentCount.Any(x => x.Value >= minSizeofGroup);
        }


    }
}
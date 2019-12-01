using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Year2019.Interfaces;

namespace AdventOfCode.Year2019.Implementations
{
    public class FuelCounterUpper : IFuelCounterUpper
    {
        public double GetRequiredFuel(in double input)
        {
            return Math.Floor(input / 3d) - 2;
        }

        public double GetRequiredFuleForMultipleModules(IEnumerable<int> modules)
        {
            return modules.Sum(x => GetRequiredFuel(x));
        }

        public double GetRequiredFuleForModulesAndFuel(double input)
        {
            var fuel = GetRequiredFuel(input);
            if (fuel <= 0)
                return 0;
            return fuel + GetRequiredFuleForModulesAndFuel(fuel);
        }

        public double GetRequiredFuleForAllModulesAndFuel(IEnumerable<int> modules)
        {
            return modules.Sum(x => GetRequiredFuleForModulesAndFuel(x));
        }
    }
}
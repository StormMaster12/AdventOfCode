using System.Collections.Generic;

namespace AdventOfCode.Year2019.Interfaces
{
    public interface IFuelCounterUpper
    {
        double GetRequiredFuel(in double input);
        double GetRequiredFuleForMultipleModules(IEnumerable<int> modules);
        double GetRequiredFuleForModulesAndFuel(double input);
        double GetRequiredFuleForAllModulesAndFuel(IEnumerable<int> modules);
    }
}
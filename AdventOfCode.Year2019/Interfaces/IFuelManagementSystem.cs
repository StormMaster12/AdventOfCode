using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode.Year2019.Interfaces
{
    public interface IFuelManagementSystem
    {
        double GetRequiredFuleForMultipleModules(IEnumerable<int> modules);
        double GetRequiredFuleForAllModulesAndFuel(IEnumerable<int> modules);

        double GetFrontPanelWiresClosestCrossingPoint(IEnumerable<string> wire1, IEnumerable<string> wire2);
    }
}
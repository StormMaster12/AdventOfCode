using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2019.Interfaces.ShipComputerFunctions
{
    public interface IShipComputerFunction
    {
        bool DoIntCodeWork(IEnumerable<int> inputs, out int result);
    }
}
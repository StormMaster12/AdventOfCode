using System;
using System.Collections.Generic;
using AdventOfCode.Year2019.Implementations.ShipComputerFunctions;

namespace AdventOfCode.Year2019.Interfaces.ShipComputerFunctions
{
    public interface IShipComputerFunction
    {
        ShipComputerFunctionModel DoIntCodeWork(ShipComputerFunctionModel model);
    }
}
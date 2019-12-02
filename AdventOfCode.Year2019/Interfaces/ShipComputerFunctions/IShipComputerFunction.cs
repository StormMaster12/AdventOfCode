using System;

namespace AdventOfCode.Year2019.Interfaces.ShipComputerFunctions
{
    public interface IShipComputerFunction
    {
        bool DoIntCodeWork(int arrayValue1, int arrayValue2, out int result);
    }
}
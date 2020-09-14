using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Year2019.Interfaces.ShipComputerFunctions;

namespace AdventOfCode.Year2019.Implementations.ShipComputerFunctions
{
    public class ComputerFunction_IntCode_Return_Input : IShipComputerFunction
    {
        public bool DoIntCodeWork(IEnumerable<int> inputs, out int result)
        {
            result = inputs.First();
            return true;
        }
    }
}
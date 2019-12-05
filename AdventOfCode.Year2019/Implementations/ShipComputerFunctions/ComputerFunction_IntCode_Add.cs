using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Year2019.Interfaces.ShipComputerFunctions;

namespace AdventOfCode.Year2019.Implementations.ShipComputerFunctions
{
    public class ComputerFunction_IntCode_Add : IShipComputerFunction
    {
        public bool DoIntCodeWork(IEnumerable<int> inputs, out int result)
        {
            result = inputs.Sum();
            return true;
        }
    }
}
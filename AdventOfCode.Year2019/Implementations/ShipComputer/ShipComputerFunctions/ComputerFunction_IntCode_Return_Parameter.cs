using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Year2019.Implementations.ShipComputerFunctions;
using AdventOfCode.Year2019.Interfaces.ShipComputerFunctions;

namespace AdventOfCode.Year2019.Implementations.ShipComputer.ShipComputerFunctions
{
    public class ComputerFunction_IntCode_Return_Parameter : IShipComputerFunction
    {
        public bool DoIntCodeWork(IEnumerable<int> inputs, out int result)
        {
            result = inputs.First();
            return true;
        }

        public ShipComputerFunctionModel DoIntCodeWork(ShipComputerFunctionModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
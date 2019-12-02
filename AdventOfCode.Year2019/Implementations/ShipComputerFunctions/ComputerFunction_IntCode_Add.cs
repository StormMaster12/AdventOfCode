using AdventOfCode.Year2019.Interfaces.ShipComputerFunctions;

namespace AdventOfCode.Year2019.Implementations.ShipComputerFunctions
{
    public class ComputerFunction_IntCode_Add : IShipComputerFunction
    {
        public bool DoIntCodeWork(int arrayValue1, int arrayValue2, out int result)
        {
            result = arrayValue1 + arrayValue2;
            return true;
        }
    }
}
using AdventOfCode.Year2019.Interfaces.ShipComputer.ShipComputerModes;

namespace AdventOfCode.Year2019.Implementations.ShipComputer.ShipComputerModes
{
    class ShipComputerMode_Position : IShipComputerMode
    {
        public int GetValue(int[] array, int parameterValue)
        {
            return array[parameterValue];
        }
    }
}
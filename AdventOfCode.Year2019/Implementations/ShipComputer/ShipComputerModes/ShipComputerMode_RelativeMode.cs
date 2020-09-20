using AdventOfCode.Year2019.Interfaces.ShipComputer.ShipComputerModes;

namespace AdventOfCode.Year2019.Implementations.ShipComputer.ShipComputerModes
{
    public class ShipComputerMode_RelativeMode : IShipComputerMode
    {
        public double GetValue(double[] program, double position, double offset, double relativeBase)
        {
            return program[(int)relativeBase + (int)program[(int)position + (int)offset]];
        }
    }
}
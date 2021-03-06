﻿using AdventOfCode.Year2019.Interfaces.ShipComputer.ShipComputerModes;

namespace AdventOfCode.Year2019.Implementations.ShipComputer.ShipComputerModes
{
    class ShipComputerMode_Immediate : IShipComputerMode
    {
        public double GetValue(double[] program, double position, double offset, double relativeBase)
        {
            return program[(int)position + (int)offset];
        }
    }
}

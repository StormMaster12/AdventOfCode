using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode.Year2019.Interfaces.ShipComputerModes;

namespace AdventOfCode.Year2019.Implementations.ShipComputerModes
{
    class ShipComputerMode_Immediate : IShipComputerMode
    {
        public int GetValue(int[] array, int parameterValue)
        {
            return parameterValue;
        }
    }
}

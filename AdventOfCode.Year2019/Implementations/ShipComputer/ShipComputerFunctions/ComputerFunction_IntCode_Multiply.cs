﻿using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Year2019.Interfaces.ShipComputerFunctions;

namespace AdventOfCode.Year2019.Implementations.ShipComputerFunctions
{
    public class ComputerFunction_IntCode_Multiply : ShipComputerFunctionBase
    {
        protected override ShipComputerFunctionModel DoWork()
        {
            Data[Data[Position + 3]] = Value2 * Value1;

            return new ShipComputerFunctionModel()
            {
                Data = Data,
                Position = Position + 3
            };
        }
    }
}
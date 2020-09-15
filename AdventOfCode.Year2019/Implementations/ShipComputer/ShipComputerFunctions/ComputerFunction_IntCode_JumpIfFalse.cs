﻿using AdventOfCode.Year2019.Implementations.ShipComputerFunctions;

namespace AdventOfCode.Year2019.Implementations.ShipComputer.ShipComputerFunctions
{
    public class ComputerFunction_IntCode_JumpIfFalse : ShipComputerFunctionBase
    {
        protected override ShipComputerFunctionModel DoWork()
        {
            if (Value1 == 0)
            {
                //Position = Data[Data[Value2]] -1;
                Position = Value2 - 1;
            }
            else
            {
                Position += 2;
            }

            return new ShipComputerFunctionModel() { Data = Data, Position = Position };
        }
    }
}
using System;
using System.Collections.Generic;
using AdventOfCode.Year2019.Implementations.ShipComputerFunctions;
using AdventOfCode.Year2019.Interfaces;
using AdventOfCode.Year2019.Interfaces.ShipComputerFunctions;

namespace AdventOfCode.Year2019.Implementations
{
    public class ShipComputer : IShipComputer
    {
        private readonly Dictionary<int, Func<IShipComputerFunction>> shipComputerFunctions = new
            Dictionary<int, Func<IShipComputerFunction>>
            {
                {1, () => new ComputerFunction_IntCode_Add()},
                {2, () => new ComputerFunction_IntCode_Multiply()},
            };

        private const int STOP_CODE = 99;

        public int[] ComputeIntCode(int[] data)
        {
            for (var i = 0; i < data.Length; i += 4)
            {
                var opCode = data[i];

                if (opCode == STOP_CODE)
                    break;

                var valuePos1 = data[i + 1];
                var valuePos2 = data[i + 2];
                var storePos = data[i + 3];

                var value1 = data[valuePos1];
                var value2 = data[valuePos2];

                var computerFunction = shipComputerFunctions[opCode].Invoke();
                if (computerFunction.DoIntCodeWork(value1, value2, out var result))
                {
                    data[storePos] = result;
                }
            }

            return data;
        }

        public int[] ComputeIntCodeSpecificValue(int[] input, in int valueToGet)
        {
            int[] inMemory = new int[input.Length];
            input.CopyTo(inMemory, 0);

            var endNumber = input.Length - 1 > 99 ? 99 : input.Length - 1;

            for (int i = 0; i <= endNumber; i++)
            {
                for (int j = 0; j <= endNumber; j++)
                {
                    inMemory[1] = j;
                    inMemory[2] = i;

                    if (ComputeIntCode(inMemory)[0] != valueToGet)
                    {
                        input.CopyTo(inMemory, 0);
                    }
                    else
                    {
                        return inMemory;
                    }
                }
            }

            return inMemory;
        }
    }
}
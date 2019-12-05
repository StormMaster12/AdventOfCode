﻿using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Business.Extensions;
using AdventOfCode.Year2019.Implementations.ShipComputerFunctions;
using AdventOfCode.Year2019.Implementations.ShipComputerModes;
using AdventOfCode.Year2019.Interfaces;
using AdventOfCode.Year2019.Interfaces.ShipComputerFunctions;
using AdventOfCode.Year2019.Interfaces.ShipComputerModes;

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

        private readonly Dictionary<int, Func<IShipComputerMode>> shipComputerModes = new Dictionary<int, Func<IShipComputerMode>>()
        {
            {0,  () => new ShipComputerMode_Position() },
            {1,  () => new ShipComputerMode_Immediate() },
        };

        private const int STOP_CODE = 99;

        public int[] ComputeIntCode(int[] data)
        {
            var intCodeLength = 4;

            for (var i = 0; i < data.Length; i += intCodeLength)
            {
                var opCode = data[i];

                if (opCode == STOP_CODE)
                    break;

                var opCodeList = opCode.ConvertIntToEnumerable().ToList();
                var storePos = 0;
                IEnumerable<int> inputList = new List<int>();

                if (opCodeList.Count() == 1)
                {
                    var valuePos1 = data[i + 1];
                    var valuePos2 = data[i + 2];
                    storePos = data[i + 3];

                    var value1 = data[valuePos1];
                    var value2 = data[valuePos2];

                    inputList = new List<int>() { value1, value2 };
                }
                else
                {
                    var handledOpCode = HandleOpCode(opCodeList, data, i + 1);
                    inputList = handledOpCode.Item2;
                    opCode = handledOpCode.opCode;

                    storePos = i + opCodeList.Count();
                }

                var computerFunction = shipComputerFunctions[opCode].Invoke();
                if (computerFunction.DoIntCodeWork(inputList, out var result))
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

        private (int opCode, IEnumerable<int>) HandleOpCode(IEnumerable<int> opCodes, int[] array, int index)
        {
            var opCodesList = opCodes.ToList();

            var endOpCode = opCodesList[^1];
            var startOpCode = opCodesList[^2];
            var inputList = new List<int>();

            var opCode = Convert.ToInt32($"{startOpCode}{endOpCode}");
            var parameters = opCodesList.Take(opCodesList.Count - 2).Reverse().ToList();

            for (int i = parameters.Count() - 1; i >= 0; i--)
            {
                var mode = shipComputerModes[parameters[i]].Invoke();
                inputList.Add(mode.GetValue(array, array[i + index]));
            }

            return (opCode, inputList);
        }
    }
}
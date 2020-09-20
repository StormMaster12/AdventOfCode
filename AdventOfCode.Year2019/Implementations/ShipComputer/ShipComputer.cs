using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Business.Extensions;
using AdventOfCode.Year2019.Implementations.ShipComputer.ShipComputerFunctions;
using AdventOfCode.Year2019.Interfaces;
using AdventOfCode.Year2019.Interfaces.ShipComputer;
using AdventOfCode.Year2019.Interfaces.ShipComputer.ShipComputerFunctions;

namespace AdventOfCode.Year2019.Implementations.ShipComputer
{
    public class ShipComputer : IShipComputer
    {
        private readonly Dictionary<int, Func<IShipComputerFunction>> _shipComputerFunctions = new Dictionary<int, Func<IShipComputerFunction>>
            {
                {1, () => new ComputerFunction_IntCode_Add()},
                {2, () => new ComputerFunction_IntCode_Multiply()},
                {3, () => new ComputerFunction_IntCode_Return_Input()},
                {4, () => new ComputerFunction_IntCode_Return_Output()},
                {5 , () => new ComputerFunction_IntCode_JumpIfTrue() },
                {6, () => new ComputerFunction_IntCode_JumpIfFalse() },
                {7, () => new ComputerFunction_IntCode_LessThan() },
                {8, () => new ComputerFunction_IntCode_EqualTo() }
            };

        private const int STOP_CODE = 99;
        private int[] _program;
        private bool _paused = false;
        private int _position = 0;
        private int _relativeBase = 0;

        public void Reset()
        {
            _paused = false;
            _program = null;
        }

        public int[] ComputeIntCode(int[] data, out int output, int input = 0)
        {
            output = 0;
            data = ComputeIntCode(data, out output, new Queue<int>(new[] { input }), out bool halted);

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

                    if (ComputeIntCode(inMemory, out var a)[0] != valueToGet)
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

        public int[] ComputeIntCode(int[] data, out int output, Queue<int> inputs, out bool halted)
        {
            output = 0;
            halted = false;
            var input = 0;

            if (!_paused)
                _program = data;

            for (var i = _position; i < _program.Length; i++)
            {
                _paused = false;
                halted = false;

                if (_program[i] == STOP_CODE)
                {
                    halted = true;
                    return _program;
                }

                var opCode = _program[i].ConvertIntToEnumerable().ToList();
                var instruction = opCode.Count() == 1 ? opCode[0] : opCode.TakeLast(2).Sum();

                var mode1 = opCode.ElementAtOrDefault(opCode.Count - 3);
                var mode2 = opCode.ElementAtOrDefault(opCode.Count - 4);

                var val1 = mode1 == 1 ? _program[i + 1] : _program.ElementAtOrDefault(_program[i + 1]);
                var val2 = mode2 == 1 ? _program[i + 2] : _program.ElementAtOrDefault(_program[i + 2]);
                var val3 = _program.ElementAtOrDefault(i + 3);

                var model = new ShipComputerFunctionModel()
                {
                    Instruction = instruction,
                    Value2 = val2,
                    Value1 = val1,
                    Value3 = val3,
                    Data = _program,
                    Position = i,
                    Output = 0
                };

                if (!_shipComputerFunctions.ContainsKey(instruction))
                {
                    halted = true;
                    return _program;
                }

                var computerFunction = _shipComputerFunctions[instruction].Invoke();

                if (inputs.Count != 0 && computerFunction is ComputerFunction_IntCode_Return_Input)
                {
                    model.Input = inputs.Dequeue();
                    input = model.Input;
                }

                var result = computerFunction.DoIntCodeWork(model);
                _program = result.Data;
                i = result.Position;

                if (result.Output > 0)
                {
                    output = result.Output;
                    _paused = true;
                    _position = i + 1;
                }

                if (halted || _paused) break;
            }

            return _program;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Business.Extensions;
using AdventOfCode.Year2019.Implementations.ShipComputer.ShipComputerFunctions;
using AdventOfCode.Year2019.Implementations.ShipComputer.ShipComputerModes;
using AdventOfCode.Year2019.Interfaces;
using AdventOfCode.Year2019.Interfaces.ShipComputer;
using AdventOfCode.Year2019.Interfaces.ShipComputer.ShipComputerFunctions;
using AdventOfCode.Year2019.Interfaces.ShipComputer.ShipComputerModes;

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
                {5, () => new ComputerFunction_IntCode_JumpIfTrue() },
                {6, () => new ComputerFunction_IntCode_JumpIfFalse() },
                {7, () => new ComputerFunction_IntCode_LessThan() },
                {8, () => new ComputerFunction_IntCode_EqualTo() },
                {9, () => new ComputerFunction_IntCode_RelativeBase() }
            };

        private readonly Dictionary<int, Func<IShipComputerMode>> _shipComputerModes = new Dictionary<int, Func<IShipComputerMode>>()
        {
            {0, () => new ShipComputerMode_Position() },
            {1, () => new ShipComputerMode_Immediate() },
            {2, () => new ShipComputerMode_RelativeMode() },
        };

        private const int STOP_CODE = 99;
        private double[] _program;
        private bool _paused = false;
        private double _position = 0;
        private double _relativeBase = 0;

        public void Reset()
        {
            _paused = false;
            _program = null;
            _position = 0;
            _relativeBase = 0;
        }

        public double[] ComputeIntCode(double[] data, out double output, double input = 0)
        {
            output = 0;
            data = ComputeIntCode(data, out output, new Queue<double>(new[] { input }), out bool halted);

            return data;
        }

        public double[] ComputeIntCodeSpecificValue(double[] input, in double valueToGet)
        {
            double[] inMemory = new double[input.Length];
            input.CopyTo(inMemory, 0);

            var endNumber = input.Length - 1 > 99 ? 99 : input.Length - 1;

            for (int i = 0; i <= endNumber; i++)
            {
                for (int j = 0; j <= endNumber; j++)
                {
                    inMemory[1] = j;
                    inMemory[2] = i;

                    var result = ComputeIntCode(inMemory, out _);
                    if (result[0] != valueToGet)
                    {
                        input.CopyTo(inMemory, 0);
                    }
                    else
                    {
                        return result;
                    }
                }
            }

            return inMemory;
        }

        public double[] ComputeIntCode(double[] data, out double output, Queue<double> inputs, out bool halted)
        {
            output = 0;
            halted = false;
            var input = 0;

            if (!_paused)
            {
                _program = data;
                _program = _program.Concat(new double[5000]).ToArray();
            }

            for (var i = _position; i < _program.Length; i++)
            {
                _paused = false;
                halted = false;

                if (_program[(int)i] == STOP_CODE)
                {
                    halted = true;
                    return _program;
                }

                var opCode = ((int)_program[(int)i]).ConvertIntToEnumerable().ToList();
                var instruction = opCode.Count() == 1 ? opCode[0] : opCode.TakeLast(2).Sum();

                var mode1 = opCode.ElementAtOrDefault(opCode.Count - 3);
                var mode2 = opCode.ElementAtOrDefault(opCode.Count - 4);

                var val1 = _shipComputerModes[(int)mode1]().GetValue(_program, i, 1, _relativeBase);// == 1 ? _program[i + 1] : _program.ElementAtOrDefault(_program[i + 1]);
                var val2 = _shipComputerModes[(int)mode2]().GetValue(_program, i, 2, _relativeBase);// mode2 == 1 ? _program[i + 2] : _program.ElementAtOrDefault(_program[i + 2]);
                var val3 = _program.ElementAtOrDefault((int)i + 3);

                var model = new ShipComputerFunctionModel()
                {
                    Instruction = instruction,
                    Value2 = val2,
                    Value1 = val1,
                    Value3 = val3,
                    Data = _program,
                    Position = i,
                    Output = 0,
                    RelativeBase = _relativeBase,
                    Input = inputs
                };

                var computerFunction = _shipComputerFunctions[(int)instruction].Invoke();

                var result = computerFunction.DoIntCodeWork(model);

                _relativeBase = result.RelativeBase ?? _relativeBase;
                _program = result.Data ?? _program;
                i = result.Position;

                if (result.Output != null)
                {
                    output = result.Output.Value;
                    _paused = true;
                    _position = i + 1;
                }

                if (halted || _paused) break;
            }

            return _program;
        }

        public double[] ReturnCopyOfProgram(double[] data, double input = 0)
        {
            var result = new List<double>();
            var dataCopy = new double[data.Length];
            data.CopyTo(dataCopy, 0);
            while (true)
            {
                ComputeIntCode(dataCopy, out var output, input);

                result.Add(output);

                if (result.Count == data.Length) break;
            }

            return result.ToArray();
        }
    }
}
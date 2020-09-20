using System.Collections.Generic;
using AdventOfCode.Year2019.Interfaces.ShipComputer.ShipComputerFunctions;

namespace AdventOfCode.Year2019.Implementations.ShipComputer.ShipComputerFunctions
{
    public abstract class ShipComputerFunctionBase : IShipComputerFunction
    {
        protected double Instruction { get; set; }
        protected double Value1 { get; set; }
        protected double Value2 { get; set; }
        protected double Value3 { get; set; }
        protected double Position { get; set; }
        protected double[] Data { get; set; }
        protected Queue<double> Input { get; set; }
        protected double RelativeBase { get; set; }

        public ShipComputerFunctionModel DoIntCodeWork(ShipComputerFunctionModel model)
        {
            Value1 = model.Value1;
            Value2 = model.Value2;
            Value3 = model.Value3;
            Position = model.Position;
            Data = model.Data;
            Input = model.Input;
            Instruction = model.Instruction;
            RelativeBase = model.RelativeBase ?? 0;

            return DoWork();
        }

        protected abstract ShipComputerFunctionModel DoWork();
    }
}
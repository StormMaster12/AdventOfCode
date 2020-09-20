using System.Collections.Generic;

namespace AdventOfCode.Year2019.Implementations.ShipComputer.ShipComputerFunctions
{
    public class ShipComputerFunctionModel
    {
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public double[] Data { get; set; }
        public double Position { get; set; }
        public Queue<double> Input { get; set; }
        public double? Output { get; set; }
        public double Value3 { get; set; }
        public double Instruction { get; set; }
        public double? RelativeBase { get; set; } = null;
    }
}

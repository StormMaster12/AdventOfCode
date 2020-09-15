using AdventOfCode.Year2019.Interfaces.ShipComputerFunctions;

namespace AdventOfCode.Year2019.Implementations.ShipComputerFunctions
{
    public abstract class ShipComputerFunctionBase : IShipComputerFunction
    {
        protected int Instruction { get; set; }
        protected int Value1 { get; set; }
        protected int Value2 { get; set; }
        protected  int Value3 { get; set; }
        protected int Position { get; set; }
        protected int[] Data { get; set; }
        protected int Input { get; set; }

        public ShipComputerFunctionModel DoIntCodeWork(ShipComputerFunctionModel model)
        {
            Value1 = model.Value1;
            Value2 = model.Value2;
            Value3 = model.Value3;
            Position = model.Position;
            Data = model.Data;
            Input = model.Input;
            Instruction = model.Instruction;

            return DoWork();
        }

        protected abstract ShipComputerFunctionModel DoWork();
    }
}
namespace AdventOfCode.Year2019.Implementations.ShipComputer.ShipComputerFunctions
{
    public class ComputerFunction_IntCode_RelativeBase : ShipComputerFunctionBase
    {
        protected override ShipComputerFunctionModel DoWork()
        {
            RelativeBase += Value1;

            return new ShipComputerFunctionModel() { RelativeBase = RelativeBase, Position = Position + 1 };
        }
    }
}
namespace AdventOfCode.Year2019.Implementations.ShipComputer.ShipComputerFunctions
{
    public class ComputerFunction_IntCode_Return_Output : ShipComputerFunctionBase
    {
        protected override ShipComputerFunctionModel DoWork()
        {
            return new ShipComputerFunctionModel()
            {
                Data = Data,
                Position = Position + 1,
                Output = Value1,
            };
        }
    }
}
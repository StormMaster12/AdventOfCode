namespace AdventOfCode.Year2019.Implementations.ShipComputer.ShipComputerFunctions
{
    public class ComputerFunction_IntCode_Return_Input : ShipComputerFunctionBase
    {
        protected override ShipComputerFunctionModel DoWork()
        {
            Data[Data[Position + 1]] = Input;
            return new ShipComputerFunctionModel()
            {
                Data = Data,
                Position = Position + 1
            };
        }
    }
}
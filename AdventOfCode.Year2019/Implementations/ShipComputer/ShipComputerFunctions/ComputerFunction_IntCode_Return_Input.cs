namespace AdventOfCode.Year2019.Implementations.ShipComputer.ShipComputerFunctions
{
    public class ComputerFunction_IntCode_Return_Input : ShipComputerFunctionBase
    {
        protected override ShipComputerFunctionModel DoWork()
        {
            Data[(int)Data[(int)Position + 1]] = Input.Dequeue();
            return new ShipComputerFunctionModel()
            {
                Data = Data,
                Position = Position + 1
            };
        }
    }
}
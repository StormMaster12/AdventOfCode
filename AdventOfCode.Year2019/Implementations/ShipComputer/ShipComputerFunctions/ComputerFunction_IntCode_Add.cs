namespace AdventOfCode.Year2019.Implementations.ShipComputer.ShipComputerFunctions
{
    public class ComputerFunction_IntCode_Add : ShipComputerFunctionBase
    {
        protected override ShipComputerFunctionModel DoWork()
        {
            Data[Data[Position + 3]] = Value2 + Value1;
            
            return new ShipComputerFunctionModel()
            {
                Data = Data,
                Position = Position + 3
            };
        }
    }
}
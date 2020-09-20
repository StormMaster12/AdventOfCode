namespace AdventOfCode.Year2019.Implementations.ShipComputer.ShipComputerFunctions
{
    public class ComputerFunction_IntCode_LessThan : ShipComputerFunctionBase
    {
        protected override ShipComputerFunctionModel DoWork()
        {
            if (Value1 < Value2)
            {
                Data[(int)Value3] = 1;
            }
            else
            {
                Data[(int)Value3] = 0;
            }

            if (Position != Value3)
            {
                Position += 3;
            }
            else
            {
                Position -= 1;
            }

            return new ShipComputerFunctionModel(){Data = Data, Position = Position};
        }
    }
}
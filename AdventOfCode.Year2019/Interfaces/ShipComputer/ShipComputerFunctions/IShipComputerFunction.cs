using AdventOfCode.Year2019.Implementations.ShipComputer.ShipComputerFunctions;

namespace AdventOfCode.Year2019.Interfaces.ShipComputer.ShipComputerFunctions
{
    public interface IShipComputerFunction
    {
        ShipComputerFunctionModel DoIntCodeWork(ShipComputerFunctionModel model);
    }
}
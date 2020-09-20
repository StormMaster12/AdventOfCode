namespace AdventOfCode.Year2019.Interfaces.ShipComputer.ShipComputerModes
{
    interface IShipComputerMode
    {
        double GetValue(double[] program, double position, double offset, double relativeBase);
    }
}

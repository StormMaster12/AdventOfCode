using System.Collections.Generic;

namespace AdventOfCode.Year2019.Interfaces.ShipComputer
{
    public interface IShipComputer
    {
        void Reset();
        double[] ComputeIntCode(double[] data, out double output, double input = 0);
        double[] ComputeIntCodeSpecificValue(double[] input, in double valueToGet);
        double[] ComputeIntCode(double[] data, out double output, Queue<double> inputs, out bool halted);
    }
}
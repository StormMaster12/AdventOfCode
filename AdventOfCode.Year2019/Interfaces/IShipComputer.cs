namespace AdventOfCode.Year2019.Interfaces
{
    public interface IShipComputer
    {
        int[] ComputeIntCode(int[] data, out int output, int input = 0);
        int[] ComputeIntCodeSpecificValue(int[] input, in int valueToGet);
    }
}
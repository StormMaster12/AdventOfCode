namespace AdventOfCode.Year2019.Interfaces
{
    public interface IAmplifierCircuit
    {
        int CalculateHighestAmplification(int[] data, bool feedback);
    }
}
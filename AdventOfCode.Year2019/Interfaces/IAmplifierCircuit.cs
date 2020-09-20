namespace AdventOfCode.Year2019.Interfaces
{
    public interface IAmplifierCircuit
    {
        double CalculateHighestAmplification(double[] data, bool feedback);
    }
}
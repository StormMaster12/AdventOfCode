namespace AdventOfCode.Year2019.Interfaces
{
    public interface IAmplifierCircuit
    {
        int Amplify(int[] data, int input, int[] phaseSetting);
        int CalculateHighestAmplification(int[] data);
    }
}
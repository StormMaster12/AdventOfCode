namespace AdventOfCode.Year2019.Interfaces
{
    public interface IPasswordGenerator
    {
        int FindValidPasswords(int start, int end);
        int FindValidPasswordsNoLargeGroupsOfNumbers(int start, int end);
    }
}
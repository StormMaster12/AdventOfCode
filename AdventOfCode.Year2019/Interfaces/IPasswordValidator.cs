namespace AdventOfCode.Year2019.Interfaces
{
    public interface IPasswordValidator
    {
        bool Validate(in int input, int minSizeofGroup = 2, bool limitGroupSizeToMinSize = false);
        //bool ValidateDigitsNotPartOfLargerGroup(in int input);
    }
}
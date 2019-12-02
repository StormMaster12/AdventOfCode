using System.Collections.Generic;

namespace AdventOfCode.Business.Services.Interfaces
{
    public interface IFileReader
    {
        IEnumerable<double> ReadFileToIntArray(string input);
        IEnumerable<int> ReadFileByLineToNumberList(string input);
        IEnumerable<int> ReadFileToNumberListBySeperator(string input, string seperator);
    }
}
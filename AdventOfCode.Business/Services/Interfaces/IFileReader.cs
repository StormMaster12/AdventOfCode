using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode.Business.Services.Interfaces
{
    public interface IFileReader
    {
        IEnumerable<double> ReadFileToIntArray(string input);
        IEnumerable<int> ReadFileByLineToNumberList(string input);
        IEnumerable<int> ReadFileToNumberListBySeperator(string input, string separator);
        IEnumerable<IEnumerable<string>> ReadFileToVectorLists(string input, string separator);
        IEnumerable<(string parent, string body)> ReadFileToValueTuple(string input, string separator);
    }
}
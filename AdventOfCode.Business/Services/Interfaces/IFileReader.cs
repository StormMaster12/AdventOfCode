using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode.Business.Services.Interfaces
{
    public interface IFileReader
    {
        IEnumerable<double> ReadFileToIntArray(string input);
        IEnumerable<int> ReadFileByLineToNumberList(string input);
        IEnumerable<int> ReadFileToNumberListBySeperator(string input, string separator);
        IEnumerable<IEnumerable<Vector2>> ReadFileToVectorLists(string input, string separator);
    }
}
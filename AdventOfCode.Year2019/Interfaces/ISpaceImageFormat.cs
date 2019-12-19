using System.Collections.Generic;
using AdventOfCode.Year2019.Implementations;

namespace AdventOfCode.Year2019.Interfaces
{
    public interface ISpaceImageFormat
    {
        List<Layer> DecodeImage(List<int> input);
    }
}
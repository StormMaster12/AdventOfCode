using System.Collections.Generic;
using AdventOfCode.Year2019.Interfaces;

namespace AdventOfCode.Year2019.Implementations
{
    public class SpaceImageFormat : ISpaceImageFormat
    {
        public List<Layer> DecodeImage(List<int> input)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Layer
    {
        public List<List<int>> Pixels = new List<List<int>>(6);
    }
}
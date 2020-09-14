using System.Collections.Generic;
using AdventOfCode.Year2019.Implementations;

namespace AdventOfCode.Year2019.Interfaces
{
    public interface ISpaceImageFormat
    {
        List<Layer> DecodeImage(List<double> input, int imageWidth, int imageHeight);
        double CheckCorruptedImage(List<Layer> layers);
        Layer BuildImage(List<Layer> input);
    }
}
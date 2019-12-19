using System.Collections.Generic;
using AdventOfCode.Year2019.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2019.Test
{
    [TestClass]
    public class SpaceImageFormatTests
    {
        [TestMethod]
        public void ImageConvertedToCorrectNumberOfLayers_TwoLayersCreated()
        {
            var expectedResult = 2;
            var input = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};

            var result = new SpaceImageFormat().DecodeImage(input);

            Assert.AreEqual(expectedResult, result.Count);
        }
    }
}
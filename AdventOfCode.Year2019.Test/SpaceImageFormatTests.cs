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
            var input = new List<double> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2 };

            var result = new SpaceImageFormat().DecodeImage(input, 3, 2);

            Assert.AreEqual(expectedResult, result.Count);
        }

        [TestMethod]
        public void ImageNotCorrupted()
        {
            var expectedResult = 4;
            var input = new List<Layer>
            {
                new Layer(3,2)
                {
                    Pixels=new List<List<double>>
                    {
                        new List<double>{0,0,1},
                        new List<double>{1,1,2}
                    }
                },
                new Layer(3,2)
                {
                    Pixels=new List<List<double>>
                    {
                        new List<double>{0,1,1},
                        new List<double>{1,1,2}
                    }
                }
            };

            var result = new SpaceImageFormat().CheckCorruptedImage(input);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void BuildImage_0110()
        {
            var expectedResult = new Layer(2,2){Pixels = new List<List<double>>(){new List<double>(){0,1}, new List<double>(){1,0}}};
            var input = new List<Layer>
            {
                new Layer(2,2)
                {
                    Pixels=new List<List<double>>
                    {
                        new List<double>{0,2},
                        new List<double>{2,2},
                    }
                },
                new Layer(2,2)
                {
                    Pixels=new List<List<double>>
                    {
                        new List<double>{1,1},
                        new List<double>{2,2}
                    }
                },
                new Layer(2,2)
                {
                    Pixels=new List<List<double>>
                    {
                        new List<double>{2,2},
                        new List<double>{1,2}
                    }
                },
                new Layer(2,2)
                {
                    Pixels=new List<List<double>>
                    {
                        new List<double>{0,0},
                        new List<double>{0,0}
                    }
                }
            };

            var result = new SpaceImageFormat().BuildImage(input);

            Assert.IsTrue(true);
        }
    }
}
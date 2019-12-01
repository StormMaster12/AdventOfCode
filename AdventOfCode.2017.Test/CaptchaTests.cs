using System.ComponentModel;
using System.Linq;
using AdventOfCode.Year2017.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode._2017.Test
{
    [TestClass]
    public class CaptchaTests
    {
        [DataTestMethod]
        [DataRow(new[] { 1d, 1, 2, 2 }, 3)]
        [DataRow(new[] { 1d, 1, 1, 1 }, 4)]
        [DataRow(new[] { 1d, 2, 3, 4 }, 0)]
        [DataRow(new[] { 9d, 1, 2, 1, 2, 1, 2, 9 }, 9)]
        public void SumNumbersThatMatchNextInSequence(double[] data, int expectedResult)
        {
            var result = new Captcha().GetSumOfNumbersMatchingNextInSequence(data.ToList());

            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(new[] { 1d, 2, 1, 2 }, 6)]
        [DataRow(new[] { 1d, 2, 2, 1 }, 0)]
        [DataRow(new[] { 1d, 2, 3, 4, 2, 5 }, 4)]
        [DataRow(new[] { 1d, 2, 3, 1, 2, 3 }, 12)]
        [DataRow(new[] { 1d, 2, 1, 3, 1, 4, 1, 5 }, 4)]
        public void SumNumbersThatAreHalfwayAroundList(double[] data, int expectedResult)
        {
            var result = new Captcha().SumNumbersThatAreHalfWayAroundList(data.ToList());

            Assert.AreEqual(expectedResult, result);
        }
    }
}
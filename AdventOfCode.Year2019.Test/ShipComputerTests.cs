using System;
using System.Linq;
using AdventOfCode.Year2019.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2019.Test
{
    [TestClass]
    public class ShipComputerTests
    {
        [DataTestMethod]
        [DataRow(new[] { 1, 0, 0, 0, 99 }, new[] { 2, 0, 0, 0, 99 })]
        [DataRow(new[] { 2, 3, 0, 3, 99 }, new[] { 2, 3, 0, 6, 99 })]
        [DataRow(new[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }, new[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 })]
        public void IntCodeCalculations(int[] data, int[] expectedResult)
        {
            var result = new ShipComputer().ComputeIntCode(data);

            Assert.IsTrue(expectedResult.SequenceEqual(result));
        }
    }
}
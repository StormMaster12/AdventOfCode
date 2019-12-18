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
        [DataRow(new[] { 1002, 4, 3, 4, 33 }, new[] { 1002, 4, 3, 4, 99 }, DisplayName = "Int Code with Modes")]
        [DataRow(new[] { 1101, 100, -1, 4, 0 }, new[] { 1101, 100, -1, 4, 99 }, DisplayName = "Int Code with Modes and Negative Number")]
        [DataRow(new[] { 1101, 99, -1, 4, 0, 1101, 100, -1, 9, 0 }, new[] { 1101, 99, -1, 4, 98, 1101, 100, -1, 9, 99 }, DisplayName = "Multiple Int Code with Modes and Negative Number")]
        [DataRow(new[] { 4, 2, 1, 0, 0, 0, 99 }, new[] { 16, 2, 2, 0, 0, 0, 99 })]
        public void IntCodeCalculations(int[] data, int[] expectedResult)
        {
            var result = new ShipComputer().ComputeIntCode(data);

            Assert.IsTrue(expectedResult.SequenceEqual(result));
        }

        [DataTestMethod]
        [DataRow(new[] { 3, 1, 4, 2, 1, 0, 0, 0, 99 }, 2, new[] { 6, 2, 2, 2, 1, 0, 0, 0, 99 })]
        public void IntCodeCalculations_With_Input(int[] data, int input, int[] expectedResult)
        {
            var result = new ShipComputer().ComputeIntCode(data, input);

            Assert.IsTrue(expectedResult.SequenceEqual(result));
        }

        [TestMethod]
        public void IntCode_GetExplicitValue()
        {
            var expectedResult = new int[] { 3, 2, 1, 0, 99 };

            var valueToGet = 3;
            var input = new[] { 1, 0, 0, 0, 99 };

            int[] result = new ShipComputer().ComputeIntCodeSpecificValue(input, valueToGet);

            Assert.IsTrue(expectedResult.SequenceEqual(result));
        }
    }
}
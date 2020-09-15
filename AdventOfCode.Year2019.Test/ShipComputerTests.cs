using System;
using System.Linq;
using AdventOfCode.Year2019.Implementations.ShipComputer;
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
        public void IntCodeCalculations(int[] data, int[] expectedResult)
        {
            var result = new ShipComputer().ComputeIntCode(data, out var a);

            Assert.IsTrue(expectedResult.SequenceEqual(result));
        }

        [DataTestMethod]
        [DataRow(new[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 }, 8, 1, DisplayName = "Check Input of 8 Equals set value of 8")]
        [DataRow(new[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 }, 7, 0, DisplayName = "Check Input of 7 Doesnt Equal set value of 8")]
        [DataRow(new[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 }, 7, 1, DisplayName = "Check if input of 7 less than set value of 8")]
        [DataRow(new[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 }, 8, 0, DisplayName = "Check if input of 8 less than set value of 8")]
        [DataRow(new[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 }, 8, 1, DisplayName = "Check Input of 8 Equals set value of 8 Using Immediate Mode")]
        [DataRow(new[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 }, 7, 0, DisplayName = "Check Input of 7 Doesnt Equals set value of 8 Using Immediate Mode")]
        [DataRow(new[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 }, 7, 1, DisplayName = "Check if input of 7 less than set value of 8 Using Immediate Mode")]
        [DataRow(new[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 }, 8, 0, DisplayName = "Check if input of 8 less than set value of 8 Using Immediate Mode")]
        public void IntCodeCalculations_Calculated_Result(int[] data, int inputValue, int expectedResult)
        {
            new ShipComputer().ComputeIntCode(data, out var result, inputValue);

            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(new[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 }, 0, 0, DisplayName = "Using Position Mode, Input is 0, result 0")]
        [DataRow(new[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 }, 1, 1, DisplayName = "Using Position Mode, Input is non 0, result 1")]
        [DataRow(new[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 }, 0, 0, DisplayName = "Using Immediate Mode, Input is 0, result 0")]
        [DataRow(new[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 }, 1, 1, DisplayName = "Using Immediate Mode, Input is non 0, result 1")]
        [DataRow(new[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 }, 1, 999, DisplayName = "Input below 8. Result 999")]
        [DataRow(new[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 }, 8, 1000, DisplayName = "Input Equals 8. Result 1000")]
        [DataRow(new[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 }, 9, 1001, DisplayName = "Input Higher 8. Result 1001")]
        public void IntCodeCalculations_JumpTests(int[] data, int inputValue, int expectedResult)
        {
            new ShipComputer().ComputeIntCode(data, out var result, inputValue);

            Assert.AreEqual(expectedResult, result);
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
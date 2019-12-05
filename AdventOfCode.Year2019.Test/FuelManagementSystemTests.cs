using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AdventOfCode.Year2019.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2019.Test
{
    [TestClass]
    public class FuelManagementSystemTests
    {
        [DataTestMethod]
        [DataRow(12, 2)]
        [DataRow(14, 2)]
        [DataRow(1969, 654)]
        [DataRow(100756, 33583)]
        public void FuelCounterForIndividualModule(int input, int expectedResult)
        {
            var result = new FuelManagementSystem().GetRequiredFuel(input);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FuelCounterForMultipleModules()
        {
            const int expectedResult = 4;
            var input = new List<int> { 12, 14 };

            var result = new FuelManagementSystem().GetRequiredFuleForMultipleModules(input);

            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(12, 2)]
        [DataRow(1969, 966)]
        [DataRow(100756, 50346)]
        public void FuelCounterForModulesAndFuel(int input, int expectedResult)
        {
            var result = new FuelManagementSystem().GetRequiredFuleForModulesAndFuel(input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FuelCounterForMultipleModulesAndFuel()
        {
            const int expectedResult = 968;
            var input = new List<int> { 12, 1969 };

            var result = new FuelManagementSystem().GetRequiredFuleForAllModulesAndFuel(input);

            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetCrossingWiresTestData), DynamicDataSourceType.Method)]
        public void GetClosestWireCrossingPoint(string[] inputArray1, string[] inputArray2, int[] expectedResult)
        {
            var result = new FuelManagementSystem().GetFrontPanelWiresClosestCrossingPoint(inputArray1.ToList(), inputArray2.ToList());
            Assert.AreEqual(expectedResult[0], result);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetShortestCrossingWiresTestData), DynamicDataSourceType.Method)]
        public void GetShortestWireCrossingPoint(string[] inputArray1, string[] inputArray2, int[] expectedResult)
        {
            var result = new FuelManagementSystem().GetFrontPanelWiresShortestPathCrossingPoint(inputArray1.ToList(), inputArray2.ToList());
            Assert.AreEqual(expectedResult[0], result);
        }


        public static IEnumerable<object[]> GetCrossingWiresTestData()
        {
            yield return new object[]{
                new[]{"R8", "U5", "L5", "D3"},
                new[] {"U7", "R6", "D4", "L4"},
                new[]{6}
            };
            yield return new object[]{
                new[]{"R75", "D30", "R83", "U83", "L12", "D49", "R71", "U7", "L72"},
                new[] {"U62", "R66", "U55", "R34", "D71", "R55", "D58", "R83"},
                new[]{159}
            };
        }

        public static IEnumerable<object[]> GetShortestCrossingWiresTestData()
        {
            yield return new object[]{
                new[]{"R75", "D30", "R83", "U83", "L12", "D49", "R71", "U7", "L72"},
                new[] {"U62", "R66", "U55", "R34", "D71", "R55", "D58", "R83"},
                new[]{610}
            };
            yield return new object[]{
                new[]{"R98", "U47", "R26", "D63", "R33", "U87", "L62", "D20", "R33", "U53", "R51"},
                new[] {"U98", "R91", "D20", "R16", "D67", "R40", "U7", "R15", "U6", "R7"},
                new[]{410}
            };
        }
    }
}

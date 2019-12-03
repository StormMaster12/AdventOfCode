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
        public void GetClosestWireCrossingPoint(Vector2[] inputArray1, Vector2[] inputArray2, int[] expectedResult)
        {
            var list = new List<List<Vector2>>(){inputArray1.ToList(), inputArray2.ToList()};
            var result = new FuelManagementSystem().GetFrontPanelWiresClosestCrossingPoint(list);

            Assert.AreEqual(expectedResult[0], result);
        }

        public static IEnumerable<object[]> GetCrossingWiresTestData()
        {
            yield return new object[]{ 
                new[] { new Vector2(-75, 0), new Vector2(0, -30), new Vector2(-83, 0), new Vector2(0, 83), new Vector2(12, 0), new Vector2(0, -49), new Vector2(-71, 0), new Vector2(0, 7), new Vector2(72, 0) },
                new[] {new Vector2(0, 62), new Vector2(66, 0), new Vector2(0, 55), new Vector2(34, 0), new Vector2(0, -71), new Vector2(55, 0), new Vector2(0, -58), new Vector2(83, 0) },
                new[]{158} };
        }
    }
}

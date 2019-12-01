using System;
using System.Collections.Generic;
using AdventOfCode.Year2019.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2019.Test
{
    [TestClass]
    public class FuelCounterUpperTests
    {
        [DataTestMethod]
        [DataRow(12, 2)]
        [DataRow(14, 2)]
        [DataRow(1969, 654)]
        [DataRow(100756, 33583)]
        public void FuelCounterForIndividualModule(int input, int expectedResult)
        {
            var result = new FuelCounterUpper().GetRequiredFuel(input);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FuelCounterForMultipleModules()
        {
            const int expectedResult = 4;
            var input = new List<int> { 12, 14 };

            var result = new FuelCounterUpper().GetRequiredFuleForMultipleModules(input);

            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(12, 2)]
        [DataRow(1969, 966)]
        [DataRow(100756, 50346)]
        public void FuelCounterForModulesAndFuel(int input, int expectedResult)
        {
            var result = new FuelCounterUpper().GetRequiredFuleForModulesAndFuel(input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FuelCounterForMultipleModulesAndFuel()
        {
            const int expectedResult = 968;
            var input = new List<int> { 12, 1969 };

            var result = new FuelCounterUpper().GetRequiredFuleForAllModulesAndFuel(input);

            Assert.AreEqual(expectedResult, result);
        }
    }
}

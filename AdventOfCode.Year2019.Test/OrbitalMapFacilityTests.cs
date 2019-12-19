using System.Collections.Generic;
using AdventOfCode.Year2019.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2019.Test
{
    [TestClass]
    public class OrbitalMapFacilityTests
    {
        [TestMethod]
        public void CalculateOrbits()
        {
            var expectedResult = 42;
            var data = new List<(string parent, string body)> { ("COM", "B"), ("B", "C"), ("C", "D"), ("D", "E"), ("E", "F"), ("B", "G"), ("G", "H"), ("D", "I"), ("E", "J"), ("J", "K"), ("K", "L") };

            int result = new OrbitalMapFacility().CalculateOrbits(data);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateOrbitalTransfers()
        {
            var expectedResult = 4;
            var data = new List<(string parent, string body)> { ("COM", "B"), ("B", "C"), ("C", "D"), ("D", "E"), ("E", "F"), ("B", "G"), ("G", "H"), ("D", "I"), ("E", "J"), ("J", "K"), ("K", "L"), ("K", "YOU"), ("I", "SAN") };

            int result = new OrbitalMapFacility().CalculateOrbitalTransfers(data, "YOU", "SAN");

            Assert.AreEqual(expectedResult, result);
        }
    }
}
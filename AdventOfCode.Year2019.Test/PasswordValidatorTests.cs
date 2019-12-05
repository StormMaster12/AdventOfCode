using AdventOfCode.Year2019.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2019.Test
{
    [TestClass]
    public class PasswordValidatorTests
    {
        [DataTestMethod]
        [DataRow(111111, true, DisplayName = "Has Double 11, values never decrease")]
        [DataRow(223450, false, DisplayName = "Decreasing Pair of Digits 50")]
        [DataRow(123789, false, DisplayName = "No Pair")]
        public void PasswordValidate(int input, bool expectedResult)
        {
            var result = new PasswordValidator().Validate(input);
            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(112233, true, DisplayName = "Digits Never Decrease, All repeated digits two digits long")]
        [DataRow(123444, false, DisplayName = "Repeated 44 part of a larger Group")]
        [DataRow(111122, true, DisplayName = "Even Though 1 is repeated more than once, still contains a double 22")]
        [DataRow(224444, true, DisplayName = "Even Though 4 is repeated more than once, still contains a double 22 at the begining")]
        [DataRow(222444, false, DisplayName = "2 and 4 Repeated more than once, so not valid")]
        public void PasswordValidate_NoLargerGroupsOfMatchingNumbers(int input, bool expectedResult)
        {
            var result = new PasswordValidator().Validate(input, limitGroupSizeToMinSize: true);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
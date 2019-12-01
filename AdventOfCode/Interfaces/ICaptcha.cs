using System.Collections.Generic;

namespace AdventOfCode.Year2017.Interfaces
{
    public interface ICaptcha
    {
        double GetSumOfNumbersMatchingNextInSequence(IEnumerable<double> data);
        double SumNumbersThatAreHalfWayAroundList(IEnumerable<double> data);
    }
}